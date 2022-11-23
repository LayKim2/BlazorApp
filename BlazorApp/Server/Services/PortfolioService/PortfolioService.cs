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
        } else
        {
            dbPortfolio.Url = portfolio.Url;
            dbPortfolio.SideName = portfolio.SideName;
            dbPortfolio.Concept1 = portfolio.Concept1;
            dbPortfolio.Concept2 = portfolio.Concept2;
            dbPortfolio.DateUpdated = DateTime.Now;
            dbPortfolio.HighlightDateUpdated = DateTime.Now;
            dbPortfolio.CameraTestDateUpdated = DateTime.Now;
            dbPortfolio.AboutBirthday = portfolio.AboutBirthday;
            dbPortfolio.AboutIntroduce = portfolio.AboutIntroduce;
            dbPortfolio.AboutSize = portfolio.AboutSize;
            dbPortfolio.AboutAge = portfolio.AboutAge;
            dbPortfolio.RightEnglishName = portfolio.RightEnglishName;
            dbPortfolio.RightName = portfolio.RightName;
            dbPortfolio.AboutImageData = portfolio.AboutImageData;
            dbPortfolio.AboutEmail = portfolio.AboutEmail;
            dbPortfolio.AboutMainFilmograpy1 =  portfolio.AboutMainFilmograpy1;
            dbPortfolio.AboutMainFilmograpy2 = portfolio.AboutMainFilmograpy2;
            dbPortfolio.AboutMainFilmograpy3 =  portfolio.AboutMainFilmograpy3;
            dbPortfolio.AboutMainFilmograpy4 =  portfolio.AboutMainFilmograpy4;
            dbPortfolio.AboutPhone = portfolio.AboutPhone;
            dbPortfolio.CamereTestUrl  =  portfolio.CamereTestUrl;
            dbPortfolio.HighlightUrl = portfolio.HighlightUrl;
            dbPortfolio.SideImageData =  portfolio.SideImageData;
            dbPortfolio.Concept1ImageData1 = portfolio.Concept1ImageData1;
            dbPortfolio.Concept1ImageData2 = portfolio.Concept1ImageData2;
            dbPortfolio.Concept1ImageData3 = portfolio.Concept1ImageData3;
            dbPortfolio.Concept1VideoUrl1 = portfolio.Concept1VideoUrl1;
            dbPortfolio.Concept1VideoUrl2 = portfolio.Concept1VideoUrl2;
            dbPortfolio.Concept2ImageData1 = portfolio.Concept2ImageData1;
            dbPortfolio.Concept2ImageData2 = portfolio.Concept2ImageData2;
            dbPortfolio.Concept2ImageData3 = portfolio.Concept2ImageData3;
            dbPortfolio.Concept2VideoUrl1 = portfolio.Concept2VideoUrl1;
            dbPortfolio.Concept2VideoUrl2 = portfolio.Concept2VideoUrl2;

            response.Data = portfolio;
        }

        await _context.SaveChangesAsync();

        return response;
    }

}
