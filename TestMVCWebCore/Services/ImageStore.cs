﻿using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCWebCore.Services
{
    public class ImageStore
    {
        CloudBlobClient blobClient;
        string baseUri = "https://levanderstorage.blob.core.windows.net/";
        public ImageStore()
        {
            var credentials = new StorageCredentials("levanderstorage", "lKdDeGhmntILnjvq/eY/mdzvdBu3bsEEzSxMWojuCW+s4eid3zrHCq/TCL+V7Btd3xh0TXRMcHvuZigGH2We9Q==");
            blobClient = new CloudBlobClient(new Uri(baseUri),credentials);
        }

        public async Task<string>SaveImage(Stream imageStream)
        {
            var imageId = Guid.NewGuid().ToString();
            var container = blobClient.GetContainerReference("images");
            var blob = container.GetBlockBlobReference(imageId);
            await blob.UploadFromStreamAsync(imageStream);

            return imageId;     // Task.FromResult(Guid.NewGuid().ToString());
        }
        public string UriFor(string ImageId)
        {
            return $"{baseUri}images/{ImageId}";
        }
    } 
}
