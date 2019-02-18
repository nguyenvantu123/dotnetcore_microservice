using System.Reflection;
using System.Threading.Tasks;
using Actio.Common.Command;
using Actio.Common.Event;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe.Middleware;

namespace Actio.Common.RabbitMq {
    public static class Extension {
        public static Task WithCommandHandleAsync<TCommand> (this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand => bus.SubscribeAsync<TCommand> (msg => handler.HandleAsync (msg),
            ctx => ctx.UseConsumeConfiguration ((q => q.WithConsumerTag (GetQueueName<TCommand> ()))));

        public static Task WithEventHandleAsync<TEvent> (this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvents => bus.SubscribeAsync<TEvent> (msg => handler.HandleAsync (msg),
            ctx => ctx.UseConsumeConfiguration ((q => q.WithConsumerTag (GetQueueName<TEvent> ()))));

        private static string GetQueueName<T> () => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

        public static void AddRabbitMq (this IServiceCollection services, IConfiguration configuration) {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);
        }
    }
}