using Microsoft.Extensions.Configuration;

namespace ConfigLib;

public class YamlConfigurationSourceProvider(YamlConfigurationSource source) : FileConfigurationProvider(source)
{
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