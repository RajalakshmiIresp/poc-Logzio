using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;


namespace LogzioSampleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            const string serviceName = "UserManagement";
            const string logzioEndpoint = "https://otlp-listener.logz.io/v1/logs";
            const string logzioToken = "znODgBxIztRFbVMOvYuXwUwGRTozaGbi";
            const string logzioMetricsToken = "vzGmoaiiHlUZWTMzAYQXuvxlKWpiYCyi";
            // Add services to the container.
            builder.Services.AddControllers();

            builder.Logging.AddOpenTelemetry(options =>
            {
                options
                    .SetResourceBuilder(
                        ResourceBuilder.CreateDefault()
                            .AddService(serviceName))
                    .AddOtlpExporter(otlpOptions =>
                    {
                        otlpOptions.Endpoint = new Uri(logzioEndpoint);
                        otlpOptions.Headers = $"Authorization=Bearer {logzioToken}, user-agent=logzio-dotnet-logs-otlp, parseJsonMessage=true";
                        otlpOptions.Protocol = OtlpExportProtocol.HttpProtobuf;
                    });
                options.IncludeFormattedMessage = true;
            });
            builder.Services.AddOpenTelemetry()
                            .ConfigureResource(resource => resource.AddService(serviceName))
                            .WithTracing(tracing => tracing
                            .AddAspNetCoreInstrumentation()
                            .AddConsoleExporter())
                            .WithMetrics(metrics => metrics
                            .AddAspNetCoreInstrumentation()
                            .AddConsoleExporter());


            var app = builder.Build();

            // Configure middleware.
            app.UseRouting();
            app.MapControllers();  // Equivalent to UseEndpoints with the modern routing system.

            // Run the application.
            app.Run();
        }
    }
}