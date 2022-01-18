using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebStorageContainer.Service
{
    public class ImageService
    {
        //get StorageAccountName
        //get StorageAccountKEy

        public async Task<string> UploadImage(HttpPostedFileBase imageToUpload)
        {
            string imageFullPath = null;
            if (imageToUpload == null)
            {
                return null;
            }

            try
            {
                string connectionString = ConnectionString.GetConnectionString();
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);

                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("c2009econtainer");

                string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(imageToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(imageToUpload.InputStream);

                imageFullPath = cloudBlockBlob.Uri.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return imageFullPath;
        }

    }

    public static class ConnectionString
    {
        public static string storageName = ConfigurationManager.AppSettings["StorageAccountName"].ToString();
        public static string storageKey = ConfigurationManager.AppSettings["StorageAccountKey"].ToString();

        public static string GetConnectionString()
        {
            return string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", storageName, storageKey);
        }

    }

}