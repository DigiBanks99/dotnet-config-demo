using Microsoft.Extensions.Configuration;

namespace ConfigLib;

public class YamlConfigurationSourceProvider : FileConfigurationProvider
{
    public YamlConfigurationSourceProvider(YamlConfigurationSource source) : base(source)
    {
    }

    public override void Load(Stream stream)
    {
        try
        {
            Data = YamlConfigurationParser.Parse(stream);
        }
        catch (Exception e)
        {
            throw new FormatException("Failed to parse YAML", e);
        }
    }
}