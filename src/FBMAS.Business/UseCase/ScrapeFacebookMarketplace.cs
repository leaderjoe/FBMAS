using System;
using System.Web;
using FBMAS.Service.Scraper;
using FBMAS.Utilities.Enums;
using Microsoft.Extensions.Logging;

namespace FBMAS.Business.UseCase;

public interface IScrapeFacebookMarketplace
{
    Task ScrapeFacebookMarketplaceAsync(string spaceDelimitedSearchCriteria, MarketplaceLocations location);
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

    public async Task ScrapeFacebookMarketplaceAsync(string spaceDelimitedSearchCriteria, MarketplaceLocations location)
    {
        _logger.LogDebug("scrapin'");
        string urlEncodedSearchCriteria = HttpUtility.UrlPathEncode(spaceDelimitedSearchCriteria);
        await _scraper.ScrapeAsync($"https://www.facebook.com/marketplace/{location}/search?deliveryMethod=local_pick_up&sortBy=creation_time_descend&query={urlEncodedSearchCriteria}&exact=false");
    }
}
