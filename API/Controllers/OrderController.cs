using API.Models;
using MassTransit;
using MessageContracts;
using MessageContracts.Commands;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ISendEndpoint _bus;

    public OrderController()
    {
        IBusControl bus = BusConfigurator.ConfigureBus();
        Uri sendToUri = new Uri($"{RabbitMQConstants.Uri}/{RabbitMQConstants.OrderServiceQueueName}");
        _bus = bus.GetSendEndpoint(sendToUri).Result;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SubmitOrderModel submitOrder)
    {
        await _bus.Send<ISubmitOrderCommand>(submitOrder);
        return Ok();
    }
}
