using Amazon.S3;
using Amazon.S3.Model;
using System.Text;

namespace ContaboObjectStoragePutObject
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = "https://eu2.contabostorage.com/",
                ForcePathStyle = true // <-- Important!
            };

            var client = new AmazonS3Client("accessKey", "secretKey", config);

            var putObjectRequest = new PutObjectRequest();
            putObjectRequest.BucketName = "mynewbucket";
            putObjectRequest.Key = "testfile.txt";
            putObjectRequest.ContentType = "text/plain";
            putObjectRequest.InputStream = new MemoryStream(Encoding.ASCII.GetBytes("Hello from Contabo Object Storage"));

            await client.PutObjectAsync(putObjectRequest);
        }
    }
}