using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPortfolio2Controller : ControllerBase
    {
        private readonly IUserPortfolioService _portfolioService;

        public UserPortfolio2Controller(IUserPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("{url}")]
        public async Task<ActionResult<ServiceResponse<Portfolio>>> GetPortfolio(string url)
        {
            return await _portfolioService.GetPortfolioByUrl(url);
        }

    }
}
