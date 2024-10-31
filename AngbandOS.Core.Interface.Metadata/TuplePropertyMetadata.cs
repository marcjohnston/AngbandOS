namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents a derived <see cref="PropertyMetadata"/> class for the description of a tuple property.
/// </summary>
public class TuplePropertyMetadata : PropertyMetadata
{
    public TuplePropertyMetadata(string propertyName) : base("tuple", propertyName) { }
    public PropertyMetadata[]? Types
    {
        get => PropertyMetadatas;
        set => PropertyMetadatas = value;
    }
}