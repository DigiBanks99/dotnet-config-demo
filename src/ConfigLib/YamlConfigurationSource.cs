using Microsoft.Extensions.Configuration;

namespace ConfigLib;

public class YamlConfigurationSource : FileConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        EnsureDefaults(builder);
        return new YamlConfigurationSourceProvider(this);
    }
}