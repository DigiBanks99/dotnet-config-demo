// See https://aka.ms/new-console-template for more information

using ConfigLib;
using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new();
configBuilder.AddEnvironmentVariables();

IConfiguration config = configBuilder.Build();

Console.WriteLine("Wheels: ");
Console.WriteLine(config.GetWheelConfigValues());
