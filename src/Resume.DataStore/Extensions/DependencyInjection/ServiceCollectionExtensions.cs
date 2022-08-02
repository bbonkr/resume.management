using System;
using kr.bbon.Data.Abstractions;
using kr.bbon.Data.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Resume.DataStore.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppDataStore(this IServiceCollection services)
    {
        services.AddRepositories(new[] {
            typeof(AppDataStore).Assembly
        });

        services.AddDataService<IDataService, AppDataStore>();

        return services;
    }
}

