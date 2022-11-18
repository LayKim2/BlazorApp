namespace BlazorApp.Server.Services.UserPortfolioService;

public class UserPortfolioService : IUserPortfolioService
{
    private readonly DataContext _context;

    public UserPortfolioService(DataContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<Portfolio>> GetPortfolioByUrl(string url)
    {
        var portfolio = await _context.Portfolios
            .FirstOrDefaultAsync(a => a.Url == url);

        return new ServiceResponse<Portfolio> { Data = portfolio };
    }
}
