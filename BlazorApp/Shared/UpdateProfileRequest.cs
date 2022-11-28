using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared;

public class UpdateProfileRequest
{
    [Required]
    public string UserName { get; set; }
    public string UserEnglishName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
