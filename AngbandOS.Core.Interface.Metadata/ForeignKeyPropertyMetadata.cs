namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents a property that is a foreign key reference to another entity collection.  This metadata is used to identify the property as a foreign key and to provide information about the referenced collection.
/// </summary>
public class ForeignKeyPropertyMetadata : PropertyMetadata
{
    public ForeignKeyPropertyMetadata(string propertyName) : base("foreign-key", propertyName) { }
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