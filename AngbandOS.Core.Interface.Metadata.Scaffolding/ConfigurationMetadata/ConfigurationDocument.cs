namespace AngbandOS.ConfigurationMetadataGenerator;

/// <summary>
/// Root JSON document.
/// </summary>
internal sealed class ConfigurationDocument
{
    public List<ConfigurationClassMetadata> Classes { get; set; } = [];
}
