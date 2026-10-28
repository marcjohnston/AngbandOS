namespace AngbandOS.ConfigurationMetadataGenerator;

internal sealed class ConfigurationClassMetadata
{
    public string Name { get; set; } = null!;

    public string? Title { get; set; }

    public string? EntityNoun { get; set; }

    public List<ConfigurationPropertyMetadata> Properties { get; set; } = [];
}
