using System;
using FBMAS.Service.Scraper;
using Microsoft.Extensions.Logging;

namespace FBMAS.Business.UseCase;

public interface IScrapeFacebookMarketplace
{
    Task ScrapeFacebookMarketplaceAsync();
}
public class ScrapeFacebookMarketplace : IScrapeFacebookMarketplace
{
    private ILogger<ScrapeFacebookMarketplace> _logger;
    private IWebScraper _scraper;
    public ScrapeFacebookMarketplace(ILogger<ScrapeFacebookMarketplace> logger, IWebScraper scraper)
    {
        _logger = logger;
        _scraper = scraper;
    }

    public async Task ScrapeFacebookMarketplaceAsync()
    {
        _logger.LogDebug("scrapin'");
        await _scraper.ScrapeAsync("https://facebook.com/marketplace");
    }
}
