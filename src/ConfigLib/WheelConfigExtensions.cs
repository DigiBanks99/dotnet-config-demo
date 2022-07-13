using Microsoft.Extensions.Configuration;

namespace ConfigLib;

public static class WheelConfigExtensions
{
    public static string GetWheelConfigValues(this IConfiguration config)
    {
        IEnumerable<IConfigurationSection>? pairs = config.GetSection("Wheel").GetChildren();
        string[] props = pairs.Select(pair => $"\"{pair.Key}\": \"{pair.Value}\"").ToArray();
        return $"{{\n{string.Join(",\n", props)}\n}}";
    }

    public static Wheel GetBoundWheelConfigValues(this IConfiguration config)
    {
        IConfigurationSection wheelSection = config.GetSection("Wheel");
        Wheel wheel = new();
        wheelSection.Bind(wheel);
        return wheel;
    }
}