namespace AngbandOS.Core.Interface;

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

    public EnumOptionMetadata[] Options { get; set; } = new EnumOptionMetadata[] { };
}