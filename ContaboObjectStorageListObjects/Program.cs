using Amazon.S3;
using Amazon.S3.Model;

namespace ContaboObjectStorageListBuckets
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

            var request = new ListObjectsV2Request();
            request.BucketName = "mynewbucket";

            var objects = await client.ListObjectsV2Async(request);

            foreach (var s3object in objects.S3Objects)
            {
                Console.WriteLine("{0}\t{1}\t{2}", s3object.Key, s3object.Size, s3object.LastModified);
            }
        }
    }
}