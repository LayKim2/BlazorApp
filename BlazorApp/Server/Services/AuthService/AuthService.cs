using BlazorApp.Client.Pages.NavMenu;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BlazorApp.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(DataContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);

    public Task<User> GetUserByEmail(string email)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
    }

    public async Task<ServiceResponse<User>> GetUser()
    {
        var id = GetUserId();
        var email = GetUserEmail();

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) & u.Id.Equals(id));

        return new ServiceResponse<User> { Data = user };
    }

    public async Task<ServiceResponse<string>> Login(string email, string password)
    {
        var response = new ServiceResponse<string>();

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

        if(user == null)
        {
            response.Success = false;
            response.Message = "User not found.";
        }
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password";
        }
        else
        {
            response.Data = CreateToken(user);
        }

        return response;
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        if(await UserExists(user.Email))
        {
            return new ServiceResponse<int> { 
                Success = false,
                Message = "User already exists." 
            };
        }

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!"};
    }

    public async Task<bool> UserExists(string email)
    {
        if(await _context.Users.AnyAsync(user => user.Email.ToLower()
            .Equals(email.ToLower())))
        {
            return true;
        }
        return false;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        // cryptography algorithm
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            // computed: 계산한
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Uri, user.ImageFileName)
                //new Claim(ClaimTypes.Role, user.Role) // TODO -- token role
            };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
    {
        var user = await _context.Users.FindAsync(userId);

        if(user == null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Message = "User not found.",
            };
        }

        CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
    }

    public async Task<ServiceResponse<bool>> UpdateProfile(int userId, UpdateProfile profile)
    {
        var email = GetUserEmail();

        var user = await _context.Users.Where(u => u.Id.Equals(userId) && u.Email.Equals(email)).FirstOrDefaultAsync();

        if(user == null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Message = "Save failed.",
            };
        }

        user.Name = profile.UserName;
        user.EnglishName = profile.UserEnglishName;
        user.PhoneNumber = profile.PhoneNumber;
        user.DateUpdated = DateTime.Now;

        await _context.SaveChangesAsync();

        return new ServiceResponse<bool> { Data = true, Message = "Profile is saved." };
    }
}
