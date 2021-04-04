using System.IO;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Infrastructure.Common;

namespace Infrastructure
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public AzureBlobStorageService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;

        }

        public async Task<bool> CreateContainer(string containerName)
        {
             var blobContainerClient = await _blobServiceClient.CreateBlobContainerAsync(containerName);
             return blobContainerClient != null && blobContainerClient.Value.Exists();
        }

        public async Task UploadFileBlobAsync(string containerName, string content, string fileName, string mimeType)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobContainerInfo = blobContainerClient.CreateIfNotExists();
            var blobClient = blobContainerClient.GetBlobClient(fileName);
            var bytes = Encoding.UTF8.GetBytes(content);
            await using var memoryStream = new MemoryStream(bytes);
            await blobClient.UploadAsync(memoryStream, new BlobHttpHeaders {ContentType = mimeType ?? fileName.GetContentType()});
        }

        public async Task UploadFileBlobUsingPathAsync(string containerName, string filePath, string fileName, string mimeType)
        {
            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobContainerInfo = blobContainerClient.CreateIfNotExists();
            var blobClient = blobContainerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(filePath, new BlobHttpHeaders {ContentType = mimeType ?? fileName.GetContentType()});
        }

        /*private async Task SetBatchStorageConnection(string connectionString)
        {
            var storageAccount = new BlobServiceClient("");// CloudStorageAccount.Parse(connectionString);
            await Task.CompletedTask;
        }*/
    }
}