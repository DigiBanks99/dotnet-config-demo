// See https://aka.ms/new-console-template for more information

using ConfigLib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;

HostingEnvironment environment = new()
{
    EnvironmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development"
};

ConfigurationBuilder configBuilder = new();
configBuilder.AddEnvironmentVariables()
    .AddEnvironmentVariables("DOTNET_")
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
    .AddYamlFile("appsettings.yml");

IConfiguration config = configBuilder.Build();

IServiceCollection services = new ServiceCollection();
services.AddWheelOptions(config);
IServiceProvider provider = services.BuildServiceProvider();

var wheel = provider.GetRequiredService<IOptionsMonitor<Wheel>>();

Console.WriteLine("Wheels: ");
Console.WriteLine(wheel.CurrentValue);