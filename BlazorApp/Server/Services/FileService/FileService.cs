using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BlazorApp.Shared.BlobTestModel;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BlazorApp.Server.Services.FileService;

public class FileService : IFileService
{
    private readonly DataContext _context;
    private readonly BlobServiceClient _blobServiceClient;
    private BlobContainerClient client;
    public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPEG", ".PNG" };

    public FileService(DataContext context, IWebHostEnvironment env, BlobServiceClient blobServiceClient)
    {
        _context = context;
        _blobServiceClient = blobServiceClient;
    }

    [HttpPost("UploadFiles")]
    public async Task<ServiceResponse<bool>> UploadFiles(UploadBlobFile uploadBlobFile)
    {
        foreach (var file in uploadBlobFile.Files)
        {
            string guidFileName;
            string extension = Path.GetExtension(file.FileName);

            client = _blobServiceClient.GetBlobContainerClient(uploadBlobFile.Container);

            guidFileName = Guid.NewGuid().ToString() + extension;

            var blobClient = client.GetBlobClient(uploadBlobFile.Location + guidFileName);

            using (var stream = file.OpenReadStream())
            {
                var status = await blobClient.UploadAsync(stream);

                // status 가 성공이면, insert / update db logic

                return new ServiceResponse<bool> { Data = true, Message = "Image has been changed." };

            }
        }

        return new ServiceResponse<bool>
        {
            Success = false,
            Message = "Image upload failed.",
        };
    }



    #region test for blob function

    public async Task<string> UploadBlobFile(string filePath, string filename)
    {
        var blobClient = client.GetBlobClient("image/" + filename);
        var status = await blobClient.UploadAsync(filePath);

        return blobClient.Uri.AbsoluteUri;
    }

    public async Task<List<string>> ListBlobs()
    {
        List<string> lst = new List<string>();

        await foreach (var blobItem in client.GetBlobsAsync())
        {
            lst.Add(blobItem.Name);
        }

        return lst;
    }

    public async Task<BlobObject> GetBlobFile(string url)
    {
        var fileName = new Uri(url).Segments.LastOrDefault();

        try
        {
            var blobClient = client.GetBlobClient(fileName);
            if (await blobClient.ExistsAsync())
            {
                BlobDownloadResult content = await blobClient.DownloadContentAsync();
                var downloadedData = content.Content.ToStream();

                if (ImageExtensions.Contains(Path.GetExtension(fileName.ToUpperInvariant())))
                {
                    var extension = Path.GetExtension(fileName);

                    return new BlobObject { Content = downloadedData, ContentType = "image/" + extension.Remove(0, 1) };
                }
                else
                {
                    return new BlobObject { Content = downloadedData, ContentType = content.Details.ContentType };
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async void DeleteBlob(string path)
    {
        var fileName = new Uri(path).Segments.LastOrDefault();
        var blobClient = client.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
    }

    #endregion

}
