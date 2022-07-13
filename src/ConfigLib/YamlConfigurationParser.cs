using System.Globalization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConfigLib;

public static class YamlConfigurationParser
{
    public static IDictionary<string, string?> Parse(Stream stream)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        using StreamReader reader = new(stream);
        string yaml = reader.ReadToEnd();
        WheelConfig config = deserializer.Deserialize<WheelConfig>(yaml);
        return new Dictionary<string, string?>
        {
            [nameof(Wheel) + ':' + nameof(Wheel.Model)] = config.Wheel?.Model,
            [nameof(Wheel) + ':' + nameof(Wheel.Diameter)] = config.Wheel?.Diameter.ToString("F2", CultureInfo.InvariantCulture)
        };
    }

    private record WheelConfig
    {
        public Wheel? Wheel { get; init; }
    }
}