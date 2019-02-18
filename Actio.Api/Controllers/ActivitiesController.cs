using System;
using System.Threading.Tasks;
using Actio.Common.Command;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Actio.Api.Controllers {
    [Route ("[controller]")]
    public class ActivitiesController : Controller {
        private readonly IBusClient _busClient;

        public ActivitiesController (IBusClient busClient) {
            _busClient = busClient;
        }

        public async Task<IActionResult> Post ([FromBody] CreateActivity command) {
            if (command == null) {
                throw new System.ArgumentNullException (nameof (command));
            }

            command.Id = Guid.NewGuid ();
            command.CreateAt = DateTime.UtcNow;

            await _busClient.PublishAsync (command);
            return Accepted ($"activities/{command.Id}");
        }

    }
}