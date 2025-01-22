using System;
using FBMAS.External.Data;
using FBMAS.External.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FBMAS.Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection collection)
    {
        collection.AddSingleton<IDapper, FBMAS.External.Data.Dapper>();
        collection.AddTransient<ILogsRepository, LogsRepository>();

        return collection;
    }


}
