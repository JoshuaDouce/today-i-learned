# Sns Publisher Service

This is a snippet of class file from [Nick Chapsas free course Cloud Fundamentals: AWS Services for C# Developers](https://nickchapsas.com/).

```C#
using System.Text.Json;

// Install AWSSDK.SimpleNotificationService
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Options;

namespace Customers.Api.Messaging;

public class SnsMessenger : ISnsMessenger
{
    // Inject SNS service
    private readonly IAmazonSimpleNotificationService _sns;

    // Get topic settings
    private readonly IOptions<TopicSettings> _topicSettings;

    // Field to store topic ARN
    private string? _topicArn;

    public SnsMessenger(IAmazonSimpleNotificationService sns, IOptions<TopicSettings> topicSettings)
    {
        _sns = sns;
        _topicSettings = topicSettings;
    }

    public async Task<PublishResponse> PublishMessageAsync<T>(T message)
    {
        var topicArn = await GetTopicArnAsync();

        var sendMessageRequest = new PublishRequest
        {
            TopicArn = topicArn,
            Message = JsonSerializer.Serialize(message),
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

        return await _sns.PublishAsync(sendMessageRequest);
    }

    /// <summary>
    /// Gets the topic ARN and saves it in a property if not already set. If set use property value
    /// Here we use value task as we only make the async call once. This is a peformance benefit.
    /// </summary>
    /// <returns></returns>
    private async ValueTask<string> GetTopicArnAsync()
    {
        if (_topicArn is not null)
        {
            return _topicArn;
        }
        
        var queueUrlResponse = await _sns.FindTopicAsync(_topicSettings.Value.Name);
        _topicArn = queueUrlResponse.TopicArn;
        return _topicArn;
    }
}

```
