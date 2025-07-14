# Sqs Messenger Service

This is a snippet of class file from [Nick Chapsas free course Cloud Fundamentals: AWS Services for C# Developers](https://nickchapsas.com/).

```C#
using System.Text.Json;

//Install AWSSDK.SQS
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Options;

namespace Customers.Api.Messaging;

public class SqsMessenger : ISqsMessenger
{
    // Inject Amazon SQS Service
    private readonly IAmazonSQS _sqs;

    // Load queue settings using IOptions
    private readonly IOptions<QueueSettings> _queueSettings;

    // Property to cache queueUrl
    private string? _queueUrl;

    public SqsMessenger(IAmazonSQS sqs, IOptions<QueueSettings> queueSettings)
    {
        _sqs = sqs;
        _queueSettings = queueSettings;
    }

    public async Task<SendMessageResponse> SendMessageAsync<T>(T message)
    {
        var queueUrl = await GetQueueUrlAsync();

        var sendMessageRequest = new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageBody = JsonSerializer.Serialize(message),
            MessageAttributes = new Dictionary<string, MessageAttributeValue>
            {
                {
                    "MessageType", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = typeof(T).Name
                    }
                }
            }
        };

        return await _sqs.SendMessageAsync(sendMessageRequest);
    }

    /// <summary>
    /// Set queue URL in the service so we don't need to make multipe calls everytime this service is used.
    /// </summary>
    /// <returns></returns>
    private async Task<string> GetQueueUrlAsync()
    {
        if (_queueUrl is not null)
        {
            return _queueUrl;
        }
        
        var queueUrlResponse = await _sqs.GetQueueUrlAsync(_queueSettings.Value.Name);
        _queueUrl = queueUrlResponse.QueueUrl;
        return _queueUrl;
    }
}
```
