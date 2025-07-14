# S3 File Service

This is a snippet of class file from [Nick Chapsas free course Cloud Fundamentals: AWS Services for C# Developers](https://nickchapsas.com/).

An example of a service that can perfrom CRUD operations for S3 objects.

```C#
// Install AWSSDK.S3
using Amazon.S3;
using Amazon.S3.Model;

namespace Customers.Api.Services;

public class ImageService : IImageService
{
    // Inject S3 Client
    private readonly IAmazonS3 _s3;
    private readonly string _bucketName = "nickawscourse";

    public ImageService(IAmazonS3 s3)
    {
        _s3 = s3;
    }

    /// <summary>
    /// Create / Update file in S3
    /// </summary>
    /// <param name="id"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    public async Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile file)
    {
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = $"images/{id}",
            ContentType = file.ContentType,
            InputStream = file.OpenReadStream(),
            // User defined meta data
            Metadata =
            {
                ["x-amz-meta-originalname"] = file.FileName,
                ["x-amz-meta-extension"] = Path.GetExtension(file.FileName),
            }
        };

        return await _s3.PutObjectAsync(putObjectRequest);
    }

    public async Task<GetObjectResponse> GetImageAsync(Guid id)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = _bucketName,
            Key = $"images/{id}"
        };

        return await _s3.GetObjectAsync(getObjectRequest);
    }

    public async Task<DeleteObjectResponse> DeleteImageAsync(Guid id)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = _bucketName,
            Key = $"images/{id}"
        };

        return await _s3.DeleteObjectAsync(deleteObjectRequest);
    }
}
```
