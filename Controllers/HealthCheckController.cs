using System.Reflection.Metadata;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogzLogPoc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        private readonly ILogger<HealthCheckController> _logger;
        private readonly string[] baseTags = { "cms", "dai", "AllocateAndLabel", "handler" };

        // Constructor to inject the logger
        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Default JSON value if no data is provided
            var defaultJson = new Dictionary<string, object>
        {
            { "userId", 0 },
            { "action", "default_action" },
            { "status", "unknown" },
            { "timestamp", DateTime.UtcNow }
        };


            _logger.LogInformation("HealthCheck endpoint accessed at New {Timestamp}", System.DateTime.UtcNow);
            _logger.LogInformation("Combained: { orderId} {tags} {@metaData} {user.userID}", 1,baseTags, defaultJson,123);
            return Ok(new { status = "Healthy", timestamp = System.DateTime.UtcNow });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
