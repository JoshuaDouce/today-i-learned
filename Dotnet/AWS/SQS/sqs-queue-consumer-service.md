# Sqs Consumer Service

This is a snippet of class file from [Nick Chapsas free course Cloud Fundamentals: AWS Services for C# Developers](https://nickchapsas.com/).

## Consumer Service

```C#
using System.Text.Json;

// Install AWSSDK.SQS
using Amazon.SQS;
using Amazon.SQS.Model;
using Customers.Consumer.Messages;

// Use MediatR for message type handling
using MediatR;
using Microsoft.Extensions.Options;

namespace Customers.Consumer;

public class QueueConsumerService : BackgroundService
{
    // Inject AWS SQS Service
    private readonly IAmazonSQS _sqs;

    // Load queue seetings using IOptions
    private readonly IOptions<QueueSettings> _queueSettings;
    private readonly IMediator _mediator;
    private readonly ILogger<QueueConsumerService> _logger;

    public QueueConsumerService(IAmazonSQS sqs, IOptions<QueueSettings> queueSettings, IMediator mediator, ILogger<QueueConsumerService> logger)
    {
        _sqs = sqs;
        _queueSettings = queueSettings;
        _mediator = mediator;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Get queue URL.
        var queueUrlResponse = await _sqs.GetQueueUrlAsync(_queueSettings.Value.Name, stoppingToken);

        var receiveMessageRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrlResponse.QueueUrl,
            AttributeNames = new List<string>{ "All" },
            MessageAttributeNames = new List<string>{ "All" },
            MaxNumberOfMessages = 1
        };

        while (!stoppingToken.IsCancellationRequested)
        {
            // Receive messsage from specified queue
            var response = await _sqs.ReceiveMessageAsync(receiveMessageRequest, stoppingToken);
            foreach (var message in response.Messages)
            {
                var messageType = message.MessageAttributes["MessageType"].StringValue;

                // Get type via namespace
                var type = Type.GetType($"Customers.Consumer.Messages.{messageType}");
                if (type is null)
                {
                    _logger.LogWarning("Unknown message type: {MessageType}", messageType);
                    continue;
                }

                // Serialize message to type
                // Using ISqsMessage as interface infront of mediatR IRequest allows us to easily allow a typed
                // seriailzation rather than a var of object.
                var typedMessage = (ISqsMessage)JsonSerializer.Deserialize(message.Body, type)!;

                try
                {
                    // Use mediatR to send to appropiate type handler
                    await _mediator.Send(typedMessage, stoppingToken);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "Message failed during processing");
                    continue;
                }                

                // Clean up by deleting message once succesfully processed
                await _sqs.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle, stoppingToken);
            }
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}

```

## MediatR Handler

```C#
using Customers.Consumer.Messages;
using MediatR;

namespace Customers.Consumer.Handlers;

public class CustomerCreatedHandler : IRequestHandler<CustomerCreated>
{
    private readonly ILogger<CustomerCreatedHandler> _logger;

    public CustomerCreatedHandler(ILogger<CustomerCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task<Unit> Handle(CustomerCreated request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(request.FullName);
        return Unit.Task;
    }
}

```
