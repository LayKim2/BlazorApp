namespace BlazorApp.Client.Services.PortfolioService;

public interface IPortfolioService
{
    bool IsEdit { get; set; }
    public Task<Portfolio> AddOrUpdatePortfolio(Portfolio portfolio);
}
