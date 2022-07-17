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

            var request = new ListBucketsRequest();
            var buckets = await client.ListBucketsAsync(request);

            foreach (S3Bucket b in buckets.Buckets)
            {
                Console.WriteLine("{0}\t{1}", b.BucketName, b.CreationDate);
            }
        }
    }
}