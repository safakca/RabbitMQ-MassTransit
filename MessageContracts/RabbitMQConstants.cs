namespace MessageContracts;

public static class RabbitMQConstants
{
    public const string Uri = "amqps://...";
    public const string Username = "...";
    public const string Password = "...";

    public const string OrderServiceQueueName = "order.service";
    public const string NotificationServiceQueueName = "notification.service";
    public const string BillingServiceQueueName = "billing.service";
}

