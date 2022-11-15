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

    public async Task<ServiceResponse<Portfolio>> AddOrUpdatePortfolio(Portfolio portfolio)
    {
        var response = new ServiceResponse<Portfolio>();

        var dbPortfolio = await _context.Portfolios
                    .Where(o => o.UserId == _authService.GetUserId() && o.Email == _authService.GetUserEmail())
                    .FirstOrDefaultAsync();

        if(dbPortfolio == null) {

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
