using System;
using System.Threading.Tasks;
using Actio.Common.Command;
using Actio.Common.Event;
using RawRabbit;

namespace Actio.Services.Activities.Handlers {
    public class CreateActivityHandler : ICommandHandler<CreateActivity> {

        private readonly IBusClient _busClient;

        public CreateActivityHandler(IBusClient busClient)
        {
            busClient = _busClient;
        }

        public async Task HandleAsync (CreateActivity command) {
            Console.WriteLine($"Creating activity: {command.Name}");
            await _busClient.PublishAsync(new ActivityCreated(command.Id,command.Category,command.Name,command.Description,command.CreateAt,command.UserId));
        }
    }
}