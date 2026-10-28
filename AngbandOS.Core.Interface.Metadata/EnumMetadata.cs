namespace AngbandOS.Core.Interface;

/// <summary>
/// Describes a reusable enumeration available to configuration metadata.
/// </summary>
public sealed class EnumMetadata
{
    public EnumMetadata(
        string name,
        EnumOptionMetadata[] options)
    {
        Name = name;
        Options = options;
    }

    /// <summary>
    /// Gets the enumeration type name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the selectable values defined by the enumeration.
    /// </summary>
    public EnumOptionMetadata[] Options { get; }
}