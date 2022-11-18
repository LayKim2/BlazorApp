namespace BlazorApp.Client.Services.UserPortfolioService;

public interface IUserPortfolioService
{
    event Action OnChange;
    Portfolio Portfolio { get; set; }

    //Task<Portfolio> GetPortfolioByUrl(string url);

    Task<ServiceResponse<Portfolio>> GetPortfolioByUrl(string url);
}
