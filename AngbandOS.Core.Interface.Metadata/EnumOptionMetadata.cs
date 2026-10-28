namespace AngbandOS.Core.Interface;

/// <summary>
/// Describes one selectable value of an enumeration.
/// </summary>
public sealed class EnumOptionMetadata
{
    public EnumOptionMetadata(
        string name,
        long value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; }

    public long Value { get; }
}