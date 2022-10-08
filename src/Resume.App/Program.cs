using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using kr.bbon.AspNetCore.Extensions.DependencyInjection;
using kr.bbon.AspNetCore.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Resume.App.Extensions.DependencyInjection;
using Resume.App.Infrastructure.Filters;
using Resume.App.Infrastructure.Identity;
using Resume.App.Infrastructure.Options;
using Resume.Data;
using MediatR;
using Resume.App;
using kr.bbon.Core.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

var assemblies = new List<Assembly>
{
     typeof(Resume.Domains.PlaceHolder).Assembly,
};

var builder = WebApplication.CreateBuilder(args);

//var dotnetRunningInContainer = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");
//var isDotnetRunningInContainer = new string[] { "true", "1" }.Contains((dotnetRunningInContainer ?? string.Empty).ToLower());
//if (isDotnetRunningInContainer)
//{
//    // I don't want to use inotify when runs in container
//    builder.Host.ConfigureAppConfiguration((_, configuration) =>
//    {
//        foreach (var source in configuration.Sources)
//        {
//            if (source is FileConfigurationSource fileConfigurationSource)
//            {
//                fileConfigurationSource.ReloadOnChange = false;
//            }
//        }
//    });
//}

// Logger
builder.Host.UseSerilog(
    configureLogger: (context, services, configuration) => configuration
        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console(),
    writeToProviders: true);


// Configure services
builder.Configuration.AddEnvironmentVariables();
builder.Services.ConfigureAppOptions();

// options
var identityServer4Options = new IdentityServer4Options();
builder.Configuration.GetSection(IdentityServer4Options.Name).Bind(identityServer4Options);

var corsConfiguration = new CorsConfiguration();
builder.Configuration.GetSection(CorsConfiguration.Name).Bind(corsConfiguration);

builder.Services.Configure<MvcOptions>(options =>
{
    options.CacheProfiles.Add("File-Response-Cache", new CacheProfile
    {
        Duration = (int)TimeSpan.FromDays(365).TotalSeconds,
    });
});

// Register Configuration
// https://github.com/NLog/NLog/wiki/ConfigSetting-Layout-Renderer
//NLog.Extensions.Logging.ConfigSettingLayoutRenderer.DefaultConfiguration = Configuration;
builder.Services.AddHttpContextAccessor();

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Sql server
    options.UseSqlServer(connectionString, sqlServerOptions =>
    {
        sqlServerOptions.MigrationsAssembly(typeof(Resume.Data.SqlServer.Placeholder).Assembly.FullName);
    });
});


builder.Services.AddMediatR(assemblies.ToArray());

builder.Services
    .AddControllersWithViews(options =>
    {
        options.Filters.Add<ApiExceptionHandlerWithLoggingFilter>();
    })
     .ConfigureApiBehaviorOptions(options =>
     {
         options.InvalidModelStateResponseFactory = context =>
         {
             PathString path = context.HttpContext.Request.Path;
             string method = context.HttpContext.Request.Method;
             string displayName = context.ActionDescriptor.DisplayName ?? string.Empty;

             var errors = context.ModelState.Values
                 .SelectMany(x => x.Errors)
                 .Select(error => JsonSerializer.Deserialize<ErrorModel>(error.ErrorMessage));

             var responseStatusCode = StatusCodes.Status400BadRequest;
             var responseModel = kr.bbon.AspNetCore.Models.ApiResponseModelFactory.Create(responseStatusCode, "Payload is invalid", errors);

             responseModel.Path = path.ToString();
             responseModel.Method = method;
             responseModel.Instance = displayName;

             context.HttpContext.Response.StatusCode = responseStatusCode;

             return new ObjectResult(responseModel) {
                 ContentTypes =
                {
                    // using static System.Net.Mime.MediaTypeNames;
                    MediaTypeNames.Application.Json,
                    MediaTypeNames.Application.Xml
                }
             };
         };
     })
    .ConfigureDefaultJsonOptions()
    .AddXmlSerializerFormatters();

//.AddFluentValidation(options =>
//{
//    options.RegisterValidatorsFromAssemblies(assemblies);
//});

builder.Services.AddIdentityServerAuthentication();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidators(assemblies);
builder.Services.AddValidatorIntercepter();

builder.Services.AddAutoMapper(assemblies.ToArray());

builder.Services.AddForwardedHeaders();

builder.Services.AddCors(options =>
{
    var origins = corsConfiguration.GetOrigins();

    options.AddPolicy(Constants.DEFAULT_CORS_POLICY, policy =>
    {
        policy.SetIsOriginAllowedToAllowWildcardSubdomains();
        if (corsConfiguration.AllowsAnyHeaders)
        {
            policy.AllowAnyHeader();
        }
        else
        {
            policy.WithHeaders(corsConfiguration.GetHeaders().ToArray());
        }

        if (corsConfiguration.AllowsAnyMethods)
        {
            policy.AllowAnyMethod();
        }
        else
        {
            policy.WithMethods(corsConfiguration.GetMethods().ToArray());
        }

        if (corsConfiguration.AllowsAnyOrigins)
        {
            policy.AllowAnyOrigin();
        }
        else
        {
            policy.WithOrigins(corsConfiguration.GetOrigins().ToArray());
        }
    });

});

var defaultVersion = new ApiVersion(1, 0);

// builder.Services.AddApiVersioningAndSwaggerGen(defaultVersion);
builder.Services.AddSwaggerGenWithIdentityServer(defaultVersion, identityServer4Options);

// Configure
var app = builder.Build();

app.UseDatabaseMigration<AppDbContext>();

// app.UseCustomExceptionHanlder();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUIWithIdentityServer(identityServer4Options);
}


// Logging
app.UseRequestLogging();

// Use proxy
// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(Constants.DEFAULT_CORS_POLICY);

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    // endpoints.MapControllers();
    endpoints.MapDefaultControllerRoute();
    // endpoints.MapFallbackToController("Index", "Home");
});

// Run web application

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger(); // Two-stage initialization https://github.com/serilog/serilog-aspnetcore#two-stage-initialization

Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine("[Serilog DEBUG] {1:yyyy-MM-dd HH:mm:ss} {0}", msg, DateTime.UtcNow));

try
{
    Log.Information("Starting web host");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}