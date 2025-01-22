using System;
using Microsoft.Extensions.Logging;

namespace FBMAS.External;

public interface IFBMASHttpClient
{
    Task<string> GetAsync(string url);
}

public class FBMASHttpClient : IFBMASHttpClient
{
    private ILogger<FBMASHttpClient> _logger;
    private HttpClient _httpClient;

    public FBMASHttpClient(ILogger<FBMASHttpClient> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task<string> GetAsync(string url)
    {
        using (var response = await _httpClient.GetAsync(url))
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
