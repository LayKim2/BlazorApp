using Microsoft.AspNetCore.Http;

namespace BlazorApp.Client.Services.FileService;

public interface IFileService
{
    Task<ServiceResponse<bool>> UploadBlobFiles(MultipartFormDataContent request);

    
}
