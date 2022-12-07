using BlazorApp.Shared.BlobTestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace BlazorApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
	private readonly IFileService _fileService;

	public FileController(IFileService fileService)
	{
		_fileService = fileService;
	}

    [HttpPost("upload-files"), Authorize]
    public async Task<ActionResult<ServiceResponse<string>>> UploadFile(List<IFormFile> files)
    {
        var container = string.Empty;
        var location = string.Empty;
        StringValues values;

        files[0].Headers.TryGetValue("Type", out values);

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        switch (values)
        {
            case "Profile":
                container = "user";
                location = $"profile/{userId}/";
                break;
        }

        if(container == string.Empty || userId == null)
        {
            return new ServiceResponse<string> {
                Success = false,
                Message = "Image upload failed.",
            };
        }

        UploadBlobFile uploadBlobFile = new()
        {
            UserID = userId,
            Files = files,
            Container = container,
            Location = location
        };

        var response = await _fileService.UploadFiles(uploadBlobFile);

        return Ok(response);
    }


    // not yet
    [HttpGet("get-file")]
    public async Task<IActionResult> GetFile(string url)
    {
        BlobObject result = await _fileService.GetFile(url);

        return File(result.Content, result.ContentType);
    }

    #region test for blob function 

    [HttpGet("GetBlobFile")]
    public async Task<IActionResult> GetBlobFile(string url)
    {
        BlobObject result = await _fileService.GetBlobFile(url);

        return File(result.Content, result.ContentType);
    }

    [HttpPost("UploadBlobFile")]
    public async Task<IActionResult> UploadBlobFile([FromBody] BlobContentModel model)
    {
        var result = await _fileService.UploadBlobFile(model.FilePath, model.FileName);

        return Ok(result);
    }

    [HttpDelete("DeleteBlob")]
    public IActionResult DeleteBlob(string path)
    {
        _fileService.DeleteBlob(path);

        return Ok();
    }

    [HttpGet("ListBlobs")]
    public async Task<IActionResult> ListBlobs()
    {
        var result = await _fileService.ListBlobs();

        return Ok(result);
    }
    #endregion
}
