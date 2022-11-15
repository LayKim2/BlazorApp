using System.Net;

namespace BlazorApp.Server.Services.PortfolioService;

public interface IPortfolioService
{
    public Task<ServiceResponse<Portfolio>> GetPortfolio();
    Task<ServiceResponse<Portfolio>> AddOrUpdatePortfolio(Portfolio portfolio);
}
