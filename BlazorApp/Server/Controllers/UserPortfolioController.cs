using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPortfolioController : ControllerBase
    {
        private readonly IUserPortfolioService _userPortfolioService;

        public UserPortfolioController(IUserPortfolioService userPortfolioService)
        {
            _userPortfolioService = userPortfolioService;
        }

        [HttpGet("{url}")]
        public async Task<ActionResult<ServiceResponse<Portfolio>>> GetPortfolio(string url)
        {
            return await _userPortfolioService.GetPortfolioByUrl(url);
        }

    }
}
