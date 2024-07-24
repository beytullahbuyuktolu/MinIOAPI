using Minio.DataModel;
using Minio;
using System.Reactive.Linq;

var endpointAddress = "localhost:9000";
var accessKey = "*****";
var secretKey = "*****";
var bucketName = "*****";


var minioClient = new MinioClient(endpointAddress, accessKey, secretKey);

await MakeBucket(minioClient, bucketName);

var filePath = @"C:\Demo\demo.txt";
await UploadFile(minioClient, bucketName, "demo.txt", filePath);

await ListFiles(minioClient, bucketName);

var downloadFilePath = @"C:\Demo\down\demo.txt";
await DownloadFile(minioClient, bucketName, "demo.txt", downloadFilePath);


static async Task MakeBucket(MinioClient minioClient, string bucketName)
{
    bool doYouHave = await minioClient.BucketExistsAsync(bucketName);
    if (!doYouHave)
        await minioClient.MakeBucketAsync(bucketName);
}

static async Task UploadFile(MinioClient minioClient, string bucketName, string objectName, string filePath)
{
    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        await minioClient.PutObjectAsync(bucketName, objectName, fileStream, fileStream.Length);
}

static async Task ListFiles(MinioClient minioClient, string bucketName)
{
    IObservable<Item> observable = minioClient.ListObjectsAsync(bucketName);
    await foreach (var item in observable.ToEnumerable().ToAsyncEnumerable())
        Console.WriteLine($"Files: {item.Key}");
}

static async Task DownloadFile(MinioClient minioClient, string bucketName, string objectName, string downloadFilePath)
{
    await minioClient.GetObjectAsync(bucketName, objectName, (stream) =>
    {
        using (var fileStream = new FileStream(downloadFilePath, FileMode.Create, FileAccess.Write))
            stream.CopyTo(fileStream);
    });
}