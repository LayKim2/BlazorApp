using Microsoft.AspNetCore.Http;

namespace BlazorApp.Client.Services.FileService;

public interface IFileService
{
    Task<ServiceResponse<string>> UploadBlobFiles(MultipartFormDataContent request);

    
}
