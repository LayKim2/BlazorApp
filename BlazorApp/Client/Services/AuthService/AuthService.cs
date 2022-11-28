using BlazorApp.Shared;

namespace BlazorApp.Client.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;

    public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
    {
        _http = http;
        _authStateProvider = authStateProvider;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }

    public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
    {
        var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);

        return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
    }

    public async Task<ServiceResponse<string>> Login(UserLogin request)
    {
        var result = await _http.PostAsJsonAsync("api/auth/login", request);

        return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }

    public async Task<ServiceResponse<int>> Register(UserRegister request)
    {
        var result = await _http.PostAsJsonAsync("api/auth/register", request);

        return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
    }

    public async Task<User> GetUser()
    {
        var response = await _http.GetFromJsonAsync<ServiceResponse<User>>("api/auth/get-user");

        return response.Data;
    }

    public async Task<ServiceResponse<bool>> UpdateProfile(UpdateProfile request)
    {
        var result = await _http.PostAsJsonAsync("api/auth/update-profile", request);

        return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
    }
}
