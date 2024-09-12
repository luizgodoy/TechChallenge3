namespace TechChallenge.Contatos.Service.Consumers
{
    using MassTransit;
    using System.Threading.Tasks;

    public class ServiceConsumer : IConsumer<ServiceConsumer>
    {
        public Task Consume(ConsumeContext<ServiceConsumer> context)
        {
            return Task.CompletedTask;
        }
    }
}