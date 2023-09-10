using MessageContracts.Commands;

namespace API.Models;

public class SubmitOrderModel : ISubmitOrderCommand
{
    public int OrderId { get; set; }

    public string OrderCode { get; set; }
}

