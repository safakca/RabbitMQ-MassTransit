using MassTransit;

namespace MessageContracts;

public class BusConfigurator
{
	public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registerationAction = null)
	{
		return Bus.Factory.CreateUsingRabbitMq(configuration =>
		{
			configuration.Host(RabbitMQConstants.Uri, hostConfiguration =>
			{
				hostConfiguration.Username(RabbitMQConstants.Username);
				hostConfiguration.Password(RabbitMQConstants.Password);
			});
			registerationAction?.Invoke(configuration);
		});
	}
} 

