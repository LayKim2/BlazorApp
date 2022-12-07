using BlazorApp.Shared.BlobTestModel;

namespace BlazorApp.Server.Services.FileService;

public interface IFileService
{
    Task<ServiceResponse<string>> UploadFiles(UploadBlobFile uploadBlobFile);

    // not yet
    Task<BlobObject> GetFile(string name);


    #region test for blob function
    Task<BlobObject> GetBlobFile(string name);
    Task<string> UploadBlobFile(string filePath, string filename);
    void DeleteBlob(string name);
    Task<List<string>> ListBlobs();
    #endregion
}
