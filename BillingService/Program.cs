using BillingService;
using MassTransit;
using MessageContracts;

Console.Title = "BillingService";

var bus = BusConfigurator.ConfigureBus(configuration =>
{
    configuration.ReceiveEndpoint(RabbitMQConstants.BillingServiceQueueName, e =>
    {
        e.Consumer<SubmittedOrderBillingEventConsumer>();
    });
});

await bus.StartAsync();

Console.WriteLine("Listening order commands..");
Console.ReadKey();

await bus.StopAsync();
