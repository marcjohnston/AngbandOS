namespace AngbandOS.ConfigurationMetadataGenerator;

internal sealed class ConfigurationPropertyMetadata
{
    public string Name { get; set; } = null!;

    public string? Title { get; set; }

    public string? Summary { get; set; }

    public string? DataType { get; set; }

    public string? Category { get; set; }

    public string? ForeignCollectionName { get; set; }

    public bool? Inline { get; set; }

    public List<ConfigurationTupleItemMetadata> TupleItems { get; set; } = [];
}
