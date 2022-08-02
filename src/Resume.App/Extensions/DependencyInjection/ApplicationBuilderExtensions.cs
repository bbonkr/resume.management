using System.IO;
using System.Linq;
using System.Net;
using kr.bbon.AspNetCore.Extensions.DependencyInjection;
using kr.bbon.AspNetCore.Models;
using kr.bbon.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Resume.App.Infrastructure.Identity;
using Serilog;
using Serilog.Events;

namespace Resume.App.Extensions.DependencyInjection;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseDatabaseMigration<TDbContext>(this IApplicationBuilder builder) where TDbContext : DbContext
    {
        using (var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
            dbContext.Database.Migrate();
        }

        return builder;
    }

    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
    {
        builder.UseSerilogRequestLogging(options =>
        {
            // Emit debug-level events instead of the defaults
            options.GetLevel = (httpContext, elapsed, ex) => LogEventLevel.Debug;

            // Attach additional properties to the request completion event
            options.EnrichDiagnosticContext = async (diagnosticContext, httpContext) =>
            {
                string ip = null;
                
                var httpMethod = httpContext.Request.Method;
                var requestUri = httpContext.Request.Path;
                string userAgent = null;
                StringValues userAgentValues;
                
                if (httpContext.Request.Headers.TryGetValue("User-Agent", out userAgentValues))
                {
                    userAgent = userAgentValues.FirstOrDefault();
                }

                ip = httpContext.Connection.RemoteIpAddress.ToString();

                string payload = null;
                string query = null;

                if (httpContext.Request.Body != null)
                {
                    httpContext.Request.EnableBuffering();

                    using (var reader = new StreamReader(httpContext.Request.Body, leaveOpen: true))
                    {
                        payload = await reader.ReadToEndAsync();

                        httpContext.Request.Body.Position = 0;
                    }
                }

                if (httpContext.Request.QueryString.HasValue)
                {
                    query = httpContext.Request.QueryString.Value.ToString();
                }

                diagnosticContext.Set("UserIp", ip);
                diagnosticContext.Set("RequestUri", requestUri);
                diagnosticContext.Set("HttpMethod", httpMethod);
                diagnosticContext.Set("Payload", payload);
                diagnosticContext.Set("QueryString", query);
                diagnosticContext.Set("IsResolved", false);
                diagnosticContext.Set("ResolvedAt", null);
                diagnosticContext.Set("UserAgent", userAgent);
            };
        });

        return builder;
    }
    
    
    public static IApplicationBuilder UseSwaggerUIWithIdentityServer(this IApplicationBuilder builder, IdentityServer4Options identityServer4Options)
    {
        builder.UseSwaggerUIWithApiVersioning(options =>
        {
            options.OAuthClientId(identityServer4Options.SwaggerClient.Id);
            options.OAuthAppName(identityServer4Options.SwaggerClient.Name);

            options.OAuthScopeSeparator(" ");
            options.OAuthUsePkce();
        });

        return builder;
    }

    public static IApplicationBuilder UseCustomExceptionHanlder(this IApplicationBuilder builder)
    {
        builder.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();
                
                if (exceptionHandlerPathFeature?.Error != null)
                {
                    var exception = exceptionHandlerPathFeature.Error;
                    var error = new ErrorModel(exception.Message,
                        ((HttpStatusCode) context.Response.StatusCode).ToString());

                    var responseData =
                        ApiResponseModelFactory.Create(context.Response.StatusCode, exception.Message, error);
                    responseData.Path = context.Request.Path;
                    responseData.Method = context.Request.Method;
                    
                    await context.Response.WriteAsJsonAsync(responseData);
                }
            });
        });
        
        return builder;
    }
}