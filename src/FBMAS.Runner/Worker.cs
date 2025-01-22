using FBMAS.Business.UseCase;

namespace runner;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _config;
    private readonly IScrapeFacebookMarketplace _fbMarketplace;

    public Worker(ILogger<Worker> logger, IConfiguration config, IScrapeFacebookMarketplace fbMarketplace)
    {
        _logger = logger;
        _config = config;
        _fbMarketplace = fbMarketplace;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int intervalSeconds = _config.GetSection("FBMAS").GetValue<int>("ScrapeIntervalSeconds");

        DateTime lastRunTime = DateTime.MinValue;

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogDebug("Worker running at: {time}", DateTimeOffset.Now);

            _logger.LogDebug("Checking to see if we should be running right now");
            var elapsedSeconds = (DateTime.UtcNow - lastRunTime).TotalSeconds;
            if (elapsedSeconds > intervalSeconds)
            {
                _logger.LogDebug("From runner kicking off the scraping of facebook marketplace");
                // fire and forget because it will be happening again
                _ = _fbMarketplace.ScrapeFacebookMarketplaceAsync();
                lastRunTime = DateTime.UtcNow;
            }
            else
            {
                _logger.LogDebug($"We have not elapsed in the configured interval seconds of {intervalSeconds}, current elapsed time: {elapsedSeconds}");
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
