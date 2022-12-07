using Microsoft.AspNetCore.Http;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.FileService;

public class FileService : IFileService
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;

    public FileService(HttpClient http, AuthenticationStateProvider authStateProvider)
    {
        _http = http;
        _authStateProvider = authStateProvider;
    }

    public async Task<bool> IsUserAuthenticated()
    {
        return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }

    public async Task<ServiceResponse<string>> UploadBlobFiles(MultipartFormDataContent request)
    {
        var result = await _http.PostAsync("/api/file/upload-files", request);

        return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
    }
}
