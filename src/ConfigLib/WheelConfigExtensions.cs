using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigLib;

public static class WheelConfigExtensions
{
    public static string GetWheelConfigValues(this IConfiguration config)
    {
        IEnumerable<IConfigurationSection>? pairs = config.GetSection("Wheel").GetChildren();
        var props = pairs.Select(pair => $"\"{pair.Key}\": \"{pair.Value}\"").ToArray();
        return $"{{\n{string.Join(",\n", props)}\n}}";
    }

    public static Wheel GetBoundWheelConfigValues(this IConfiguration config)
    {
        var wheelSection = config.GetSection("Wheel");
        Wheel wheel = new();
        wheelSection.Bind(wheel);
        return wheel;
    }

    public static IServiceCollection AddWheelOptions(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<Wheel>(config.GetSection("Wheel"));
        return services;
    }

    public static IConfigurationBuilder AddYamlFile(this IConfigurationBuilder builder, string path,
        bool optional = true, bool reloadOnChange = false)
    {
        YamlConfigurationSource source = new()
        {
            Path = path,
            Optional = optional,
            ReloadOnChange = reloadOnChange
        };
        source.ResolveFileProvider();

        return builder.Add(source);
    }
}