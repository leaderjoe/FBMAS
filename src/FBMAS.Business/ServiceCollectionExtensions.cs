using System;
using FBMAS.Service;
using FBMAS.Service.Scraper;
using Microsoft.Extensions.DependencyInjection;

namespace FBMAS.Business;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
        collection.AddRepositories();
        collection.AddTransient<IWebScraper, WebScraper>();
        return collection;
    }
}
