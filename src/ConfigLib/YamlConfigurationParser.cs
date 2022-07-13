using System.Globalization;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConfigLib;

public static class YamlConfigurationParser
{
    public static IDictionary<string, string> Parse(Stream stream)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        
        using StreamReader reader = new(stream);
        WheelConfig wheel = deserializer.Deserialize<WheelConfig>(reader);
        return new Dictionary<string, string>
        {
            [nameof(Wheel) + ':' + nameof(Wheel.Model)] = wheel.Wheel.Model,
            [nameof(Wheel) + ':' + nameof(Wheel.Diameter)] = wheel.Wheel.Diameter.ToString("F2", CultureInfo.InvariantCulture)
        };
    }
    
    private class WheelConfig
    {
            public Wheel Wheel { get; set; }
    }
}