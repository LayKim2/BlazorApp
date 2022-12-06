
using Microsoft.AspNetCore.Http;

namespace BlazorApp.Shared;

public class UploadBlobFile
{
    public string UserID { get; set; } = string.Empty;
    public List<IFormFile> Files { get; set; }
    public string Container { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}
