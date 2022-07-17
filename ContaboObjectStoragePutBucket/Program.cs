using Amazon.S3;

namespace ContaboObjectStoragePutBucket
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

            await client.PutBucketAsync("mynewbucket");
        }
    }
}