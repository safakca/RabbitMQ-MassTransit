using MassTransit;
using MessageContracts.Commands;
using MessageContracts.Events;

namespace OrderService;

public class SubmitOrderCommandConsumer : IConsumer<ISubmitOrderCommand>
{
	public async Task Consume(ConsumeContext<ISubmitOrderCommand> context)
	{
		var message = context.Message;
		Console.WriteLine($"Succesfully. Id: {message.OrderId} - Order Code: {message.OrderCode}");

		await context.Publish<IOrderSubmittedEvent>(new
		{
			message.OrderId,
			message.OrderCode,
			Success = true
		});
	}
}

