using System.Threading.Tasks;
using Actio.Common.Command;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Actio.Api.Controllers {
    [Route ("[controller]")]
    public class UserController : Controller {
        private readonly IBusClient _busClient;

        public UserController (IBusClient busClient) {
            _busClient = busClient;
        }

        [HttpPost ("register")]
        public async Task<IActionResult> Post ([FromBody] CreateUser command) {
            if (command == null) {
                throw new System.ArgumentNullException (nameof (command));
            }

            await _busClient.PublishAsync (command);
            return Accepted ();
        }
    }
}