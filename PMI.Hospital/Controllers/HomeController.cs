using Microsoft.AspNetCore.Mvc;
using PMI.Hospital.Infrastructure.Persistence.DatabaseContext;

namespace PMI.Hospital.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("allUsers")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Get()
        {
            return _context.People.FirstOrDefault()?.Id ?? "EMPTY";
        }
    }
}
