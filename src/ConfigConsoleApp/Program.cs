// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new();
configBuilder.AddEnvironmentVariables();

IConfiguration config = configBuilder.Build();
var pairs = config.GetSection("Wheel")
    .GetChildren();

Console.WriteLine("Wheels: ");
string[] props = pairs.Select(pair => $"\"{pair.Key}\": \"{pair.Value}\"").ToArray();
Console.WriteLine($"{{\n{string.Join(",\n", props)}\n}}");
