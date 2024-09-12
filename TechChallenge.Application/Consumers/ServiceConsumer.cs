using MassTransit;
using System.Threading.Tasks;

namespace TechChallenge.Contatos.Service.Consumers
{
    public class ServiceConsumer : IConsumer<ServiceConsumer>
    {
        public Task Consume(ConsumeContext<ServiceConsumer> context)
        {
            return Task.CompletedTask;
        }
    }
}