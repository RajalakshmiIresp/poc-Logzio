using log4net;
using log4net.Config;

namespace LogzioLog4netSampleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            XmlConfigurator.Configure();

            var app = builder.Build();

            // Configure middleware.
            app.UseRouting();
            app.MapControllers();  // Equivalent to UseEndpoints with the modern routing system.

            // Run the application.
            app.Run();
        }
    }
}