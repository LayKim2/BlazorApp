namespace BlazorApp.Server.Services.PortfolioService;

public interface IPortfolioService
{
    Task<ServiceResponse<Portfolio>> AddOrUpdatePortfolio(Portfolio portfolio);
}
