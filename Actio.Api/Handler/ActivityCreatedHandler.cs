using System;
using System.Threading.Tasks;
using Actio.Common.Event;
using RawRabbit;

namespace Actio.Api.Handler {
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated> {

        // private readonly IBusClient _busClient;

        // public ActivityCreatedHandler (IBusClient busClient) {
        //     _busClient = busClient;
        // }

        // async Task IEventHandler<ActivityCreated>.HandleAsync(ActivityCreated command)
        // {
        //      Console.WriteLine ($"Creating activity: {command.Name}");
        //     await _busClient.PublishAsync (new ActivityCreated (command.Id, command.Name, command.Category, command.Description, command.CreateAt, command.UserId));
        public async Task HandleAsync (ActivityCreated @event) {
            await Task.CompletedTask;
            Console.WriteLine ($"Activity Created: { @event.Name}");
        }
    }
}