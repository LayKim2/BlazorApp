namespace BlazorApp.Server.Services.UserPortfolioService;

public interface IUserPortfolioService
{
    public Task<ServiceResponse<Portfolio>> GetPortfolioByUrl(string url);
}
