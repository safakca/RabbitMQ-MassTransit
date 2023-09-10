using MassTransit;
using MessageContracts;
using NotificationService;

Console.Title = "NotificationService";

var bus = BusConfigurator.ConfigureBus(configuration =>
{
    configuration.ReceiveEndpoint(RabbitMQConstants.NotificationServiceQueueName, e =>
    {
        e.Consumer<SubmittedOrderNotificationEventConsumer>();
    });
});

await bus.StartAsync();

Console.WriteLine("Listening order commands..");
Console.ReadKey();

await bus.StopAsync();