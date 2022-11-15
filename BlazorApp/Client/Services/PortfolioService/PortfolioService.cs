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
    public Portfolio Portfolio { get; set; } = new Portfolio();

    public event Action OnChange;
    public async Task<Portfolio> GetPortfolio()
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<Portfolio>>("api/portfolio");

        return response.Data;
    }

    public async Task<Portfolio> AddOrUpdatePortfolio(Portfolio portfolio)
    {
        var response = await _http.PostAsJsonAsync("api/portfolio", portfolio);

        return response.Content.ReadFromJsonAsync<ServiceResponse<Portfolio>>().Result.Data;
    }

}
