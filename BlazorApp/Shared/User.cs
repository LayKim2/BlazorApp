namespace BlazorApp.Shared;

public class User
{
    public int Id { get; set; } 
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string EnglishName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateUpdated { get; set; } = DateTime.Now;
    public string ImageFileName { get; set; } = string.Empty;


    //public Address Address { get; set; }
    //public string Role { get; set; } = "Customer";
}