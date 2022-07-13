// See https://aka.ms/new-console-template for more information

using ConfigLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;

HostingEnvironment environment = new()
{
    EnvironmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development"
};

ConfigurationBuilder configBuilder = new();
configBuilder.AddEnvironmentVariables()
    .AddEnvironmentVariables("DOTNET_")
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true);

IConfiguration config = configBuilder.Build();

Console.WriteLine("Wheels: ");
Console.WriteLine(config.GetBoundWheelConfigValues());
