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

    public new string? ForeignCollectionName
    {
        get => base.ForeignCollectionName;
        set => base.ForeignCollectionName = value;
    }

    public new bool? Inline
    {
        get => base.Inline;
        set => base.Inline = value;
    }

}