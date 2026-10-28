namespace AngbandOS.ConfigurationMetadataGenerator;

internal sealed class ConfigurationTupleItemMetadata
{
    public string Name { get; set; } = null!;

    public string? Title { get; set; }

    public string? Summary { get; set; }

    public string? ForeignCollectionName { get; set; }
}