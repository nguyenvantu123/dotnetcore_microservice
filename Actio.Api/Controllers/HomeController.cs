using Microsoft.AspNetCore.Mvc;

namespace Actio.Api.Controllers {
    public class HomeController : Controller {
        [HttpGet ("")]
        public IActionResult Get () => Content ("Hello API");
    }
}