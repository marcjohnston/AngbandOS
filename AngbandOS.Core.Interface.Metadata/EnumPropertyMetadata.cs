namespace AngbandOS.Core.Interface.Metadata;

/// <summary>
/// Represents metadata for an enumeration-valued configuration property.
/// </summary>
public sealed class EnumPropertyMetadata : PropertyMetadata
{
    public EnumPropertyMetadata(
        string propertyName)
        : base("enum", propertyName)
    {
    }

    /// <summary>
    /// Gets or sets the name of the shared enumeration metadata.
    /// </summary>
    public string EnumName { get; set; } = string.Empty;
}