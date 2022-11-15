using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BlazorApp.Server.Services.PortfolioService;

public class PortfolioService : IPortfolioService
{
    private readonly DataContext _context;
    private readonly IAuthService _authService;

    public PortfolioService(DataContext context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
    }

    public async Task<ServiceResponse<Portfolio>> GetPortfolio()
    {
        int userId = _authService.GetUserId();
        string email = _authService.GetUserEmail();
        var portfolio = await _context.Portfolios
            .FirstOrDefaultAsync(a => a.UserId == userId && a.Email == email);

        return new ServiceResponse<Portfolio> { Data = portfolio };
    }

    public async Task<ServiceResponse<Portfolio>> AddOrUpdatePortfolio(Portfolio portfolio)
    {
        var response = new ServiceResponse<Portfolio>();

        var dbPortfolio = (await GetPortfolio()).Data;

        if (dbPortfolio == null) {

            portfolio.UserId = _authService.GetUserId();
            portfolio.Email = _authService.GetUserEmail();

            _context.Portfolios.Add(portfolio);

            response.Data = portfolio;
        } else {
            dbPortfolio.SideName = portfolio.SideName;
            dbPortfolio.Concept1 = portfolio.Concept1;
            dbPortfolio.Concept2 = portfolio.Concept2;

            response.Data = portfolio;
        }

        await _context.SaveChangesAsync();

        return response;
    }

}
