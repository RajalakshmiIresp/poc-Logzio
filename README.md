# Logzio-Logs

## Prerequisites:
.Net Core SDK version 2.0 or above

- [log4net appender installation and configuration](docs/log4net.md)  [![NuGet](https://img.shields.io/nuget/v/Logzio.DotNet.Log4net.svg)](https://www.nuget.org/packages/Logzio.DotNet.Log4net)
- [NLog target installation and configuration](docs/nlog.md) [![NuGet](https://img.shields.io/nuget/v/Logzio.DotNet.NLog.svg)](https://www.nuget.org/packages/Logzio.DotNet.NLog)


## Build and Test Locally
This project uses .NET 8.0 and can be built and tested locally. Follow the steps below to do so:

1. Update the token details in App.config file
2. Build the solution
3. Run the solution
4. Run the below health check endpoint in browser 
   https://localhost:7061/api/healthcheck
