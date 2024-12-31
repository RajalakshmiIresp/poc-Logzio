using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogzLogPoc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        private readonly ILogger<HealthCheckController> _logger;

        // Constructor to inject the logger
        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("HealthCheck endpoint accessed at {Timestamp}", System.DateTime.UtcNow);
            return Ok(new { status = "Healthy", timestamp = System.DateTime.UtcNow });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
