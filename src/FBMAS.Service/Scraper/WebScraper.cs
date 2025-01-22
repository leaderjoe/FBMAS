using System;
using System.Net.Http;
using FBMAS.External;
using FBMAS.External.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace FBMAS.Service.Scraper;

public interface IWebScraper
{
    Task ScrapeAsync(string url);
}

public class WebScraper : IWebScraper
{
    private ILogger<WebScraper> _logger;
    private ILogsRepository _logsRepo;
    private IFBMASHttpClient _httpClient;
    public WebScraper(ILogger<WebScraper> logger, ILogsRepository logsRepo, IFBMASHttpClient httpClient)
    {
        _logger = logger;
        _logsRepo = logsRepo;
        _httpClient = httpClient;
    }

    public async Task ScrapeAsync(string url)
    {
        _logger.LogDebug($"Scraping website {url}");

        string fbMarketplacePage = await _httpClient.GetAsync(url);

        await Task.Delay(1000);

        await _logsRepo.AddLogAsync($"Scraped website {url}");

        _logger.LogDebug($"Done scraping website {url}");
    }
}
