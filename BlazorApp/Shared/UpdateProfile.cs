using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared;

public class UpdateProfile
{
    [Required]
    public string UserName { get; set; }
    public string UserEnglishName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserImage { get; set; } // base64 or storage url => only bind
}
