using Microsoft.AspNetCore.Mvc;

namespace PMI.Hospital.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("allUsers")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<string> Get()
        {
            return null;
        }
    }
}
