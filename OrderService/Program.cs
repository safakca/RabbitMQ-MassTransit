using MassTransit;
using MessageContracts;
using OrderService;

Console.Title = "OrderService";

IBusControl bus = BusConfigurator.ConfigureBus(async configuration =>
{
    configuration.ReceiveEndpoint(RabbitMQConstants.OrderServiceQueueName, e =>
    {
        e.Consumer<SubmitOrderCommandConsumer>();
    });
});

await bus.StartAsync();

Console.WriteLine("Listening order commands...");
Console.ReadKey();

await bus.StopAsync();

