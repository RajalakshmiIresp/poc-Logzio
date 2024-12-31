# LogzioSampleApplication

This project demonstrates how to integrate OpenTelemetry with Logz.io for logging, metrics, and tracing. The application includes a HealthCheck endpoint to verify its functionality and logs its access to Logz.io.

---

## Features

- **HealthCheck Endpoint**: Provides a simple API to check the health status of the application.
- **OpenTelemetry Integration**: Captures logs, metrics, and traces.
- **Logz.io Exporter**: Sends OpenTelemetry data (logs, metrics, traces) to Logz.io.

---

## Prerequisites

- .NET 6 SDK or higher
- Logz.io account with generated tokens for Logs and Metrics
- An active internet connection for sending telemetry data to Logz.io

---

## Setup Instructions

### 1.Install Required NuGet Packages
Run the following command to install the necessary NuGet packages:
```bash
dotnet add package OpenTelemetry --version 1.6.0
dotnet add package OpenTelemetry.Extensions.Hosting --version 1.6.0
dotnet add package OpenTelemetry.Exporter.Console --version 1.6.0
dotnet add package OpenTelemetry.Exporter.OpenTelemetryProtocol --version 1.6.0
dotnet add package Microsoft.Extensions.Logging.Console --version 7.0.0
dotnet add package Microsoft.AspNetCore.Mvc.Core --version 2.2.0
```

### 2.Configure Environment Variables
Replace the placeholder tokens in Program.cs with your actual Logz.io tokens:

- **logzioToken**: Logz.io token for logs.
- **logzioMetricsToken**: Logz.io token for metrics.

### 3.Build and Run the Application
```bash
dotnet build
dotnet run
```

## Application Structure
### HealthCheckController.cs
- Defines an API endpoint /api/healthcheck.
- Logs each access with a timestamp.
- Returns the health status (Healthy) and a UTC timestamp in the response.
### Program.cs
- Configures OpenTelemetry for:
   - Logging: Sends logs to Logz.io using the OTLP exporter.
   - Metrics: Captures application-level metrics.
   - Tracing: Enables distributed tracing.
- Sets up middleware for routing and maps controllers.

## API Details
### HealthCheck Endpoint
- URL: /api/healthcheck
- Method: GET
- Response
   ```bash
      {
         "status": "Healthy",
         "timestamp": "2024-12-31T00:00:00Z"
      }
   ```
## Logging, Metrics, and Tracing
### Logging
- Logs are sent to Logz.io using the OpenTelemetry OTLP Exporter.
- Example log message:
```bash
HealthCheck endpoint accessed at 2024-12-31T00:00:00Z
```
### Metrics
- Application metrics are collected via OpenTelemetry and can be extended as needed.
### Tracing
- Traces are captured using OpenTelemetry's ASP.NET Core instrumentation.
### Dependencies
This project relies on the following 
# Dependencies

This project relies on the following NuGet packages:

| Package                                      | Version  |
|----------------------------------------------|----------|
| `OpenTelemetry`                              | 1.6.0    |
| `OpenTelemetry.Extensions.Hosting`           | 1.6.0    |
| `OpenTelemetry.Exporter.Console`             | 1.6.0    |
| `OpenTelemetry.Exporter.OpenTelemetryProtocol` | 1.6.0  |
| `Microsoft.Extensions.Logging.Console`       | 7.0.0    |
| `Microsoft.AspNetCore.Mvc.Core`              | 2.2.0    |



