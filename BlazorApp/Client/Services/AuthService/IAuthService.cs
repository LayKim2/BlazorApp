using BlazorApp.Shared;

namespace BlazorApp.Client.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(UserRegister request);
    Task<ServiceResponse<string>> Login(UserLogin request);
    Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
    Task<bool> IsUserAuthenticated();
    Task<User> GetUser();
    Task<ServiceResponse<bool>> UpdateProfile(UpdateProfile request);
}
