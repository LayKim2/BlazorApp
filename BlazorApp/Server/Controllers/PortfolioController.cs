using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Portfolio>>> AddorUpdatePortfolio(Portfolio portfolio)
        {
            return await _portfolioService.AddOrUpdatePortfolio(portfolio);
        }
    }
}
