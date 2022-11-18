namespace BlazorApp.Client.Services.UserPortfolioService;

public class UserPortfolioService : IUserPortfolioService
{
    private readonly HttpClient _http;

    public UserPortfolioService(HttpClient http)
    {
        _http = http;
    }

    public Portfolio Portfolio { get; set; } = new Portfolio();
    public event Action OnChange;

    public async Task<ServiceResponse<Portfolio>> GetPortfolioByUrl(string url)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Portfolio>>($"api/userportfolio2/{url}");

        return result;
    }

}
