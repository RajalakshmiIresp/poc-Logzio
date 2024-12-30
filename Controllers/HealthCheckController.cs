using log4net;
using Microsoft.AspNetCore.Mvc;

namespace LogzLogPoc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
       private static readonly ILog logger = LogManager.GetLogger(typeof(HealthCheckController));
        
        [HttpGet]
        public IActionResult Get()
        {
            logger.Info("User Management Service Health check endpoint hit.");
            logger.Warn("This is a warning log for testing Logz.io.");
            logger.Error("This is an error log for testing Logz.io.");
            return Ok(new { status = "Healthy", timestamp = System.DateTime.UtcNow });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
