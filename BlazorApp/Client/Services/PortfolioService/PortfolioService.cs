using System.Net;

namespace BlazorApp.Client.Services.PortfolioService;

public class PortfolioService : IPortfolioService
{
    private readonly HttpClient _http;

    public PortfolioService(HttpClient http)
    {
        _http = http;
    }

    public bool IsEdit { get; set; } = false;

    public async Task<Portfolio> AddOrUpdatePortfolio(Portfolio portfolio)
    {
        var response = await _http.PostAsJsonAsync("api/portfolio", portfolio);

        return response.Content.ReadFromJsonAsync<ServiceResponse<Portfolio>>().Result.Data;
    }
}
