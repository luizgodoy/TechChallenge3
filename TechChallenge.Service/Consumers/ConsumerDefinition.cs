namespace TechChallenge.Contatos.Service.Consumers
{
    using MassTransit;

    public class ConsumerDefinition :
        ConsumerDefinition<ServiceConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ServiceConsumer> consumerConfigurator, IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

            endpointConfigurator.UseInMemoryOutbox(context);
        }
    }
}