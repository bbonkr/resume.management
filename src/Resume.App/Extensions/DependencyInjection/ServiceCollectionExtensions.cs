using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using FluentValidation.AspNetCore;
using kr.bbon.AspNetCore.Extensions.DependencyInjection;
using kr.bbon.AspNetCore.Models;
using kr.bbon.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Resume.App.Infrastructure.Identity;
using Resume.App.Infrastructure.Swagger;
using Resume.App.Infrastructure.Validations;
using FluentValidation;
using System.Collections.Generic;

namespace Resume.App.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidatorIntercepter(this IServiceCollection services)
    {
        services.AddTransient<IValidatorInterceptor, ValidatorInterceptor>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
    
    public static IServiceCollection AddIdentityServerAuthentication(this IServiceCollection services)
    {
        var identityServer4Options = new IdentityServer4Options();
        // configuration.GetSection(IdentityServer4Options.Name).Bind(identityServer4Options);

        services.AddOptions<IdentityServer4Options>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                configuration.GetSection(IdentityServer4Options.Name).Bind(options);

                identityServer4Options = options;
            });


        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
                
            })
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = identityServer4Options.Issuer;
                options.Audience = identityServer4Options.ApiName;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    RoleClaimType = ClaimTypes.Role,
                    NameClaimType = ClaimTypes.NameIdentifier,
                };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        var error = new ErrorModel("You are not authorized", HttpStatusCode.Unauthorized.ToString());
                        
                        var responseModel =
                            ApiResponseModelFactory.Create(StatusCodes.Status401Unauthorized, error.Message, error);
                        responseModel.Path = context.Request.Path;
                        // responseModel.Instance = Activity.Current.Id;
                        responseModel.Method = context.Request.Method;
                        
                        await context.Response.WriteAsJsonAsync(responseModel);
                    }
                };
            });
            // .AddIdentityServerAuthentication("Bearer", options =>
            // {
            //     // required audience of access tokens
            //     options.ApiName = identityServer4Options.ApiName;
            //     // auth server base endpoint (this will be used to search for disco doc)
            //     options.Authority = identityServer4Options.Issuer;
            //     options.NameClaimType = ClaimTypes.NameIdentifier;
            //     options.RoleClaimType = ClaimTypes.Role;
            //     options.RequireHttpsMetadata = false;
            // });

        return services;
    }    
    
    public static IServiceCollection AddSwaggerGenWithIdentityServer(this IServiceCollection services, ApiVersion defaultVersion, IdentityServer4Options identityServer4Options)
    {
        services.AddApiVersioningAndSwaggerGen(defaultVersion, options =>
        {
            options.OperationFilter<AuthorizeCheckOperationFilter>();

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri($"{identityServer4Options.Issuer}/connect/authorize"),
                        TokenUrl = new Uri($"{identityServer4Options.Issuer}/connect/token"),
                        Scopes = identityServer4Options.Scopes.ToDictionary(x => x.Name, x => x.DisplayName),
                    }
                }
            });
            
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services, IEnumerable<Assembly> assemblies, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        services.AddValidatorsFromAssemblies(assemblies, serviceLifetime);

        return services;
    }
}