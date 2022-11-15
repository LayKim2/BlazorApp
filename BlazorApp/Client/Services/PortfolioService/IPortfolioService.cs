using System.Net;

namespace BlazorApp.Client.Services.PortfolioService;

public interface IPortfolioService
{
    event Action OnChange;
    Portfolio Portfolio { get; set; }
    bool IsEdit { get; set; }

    public Task<Portfolio> GetPortfolio();
    public Task<Portfolio> AddOrUpdatePortfolio(Portfolio portfolio);
}
