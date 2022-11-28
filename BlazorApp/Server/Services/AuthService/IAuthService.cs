namespace BlazorApp.Server.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(User user, string password);
    Task<bool> UserExists(string email);
    Task<ServiceResponse<string>> Login(string email, string password);
    Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword);
    int GetUserId();
    string GetUserEmail();
    Task<User> GetUserByEmail(string email);

    Task<ServiceResponse<User>> GetUser();
    Task<ServiceResponse<bool>> UpdateProfile(int userId, UpdateProfile profile);

}
