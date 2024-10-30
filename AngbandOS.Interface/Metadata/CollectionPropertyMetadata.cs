namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName) : base("collection", propertyName) { }

    public new PropertyMetadata[]? PropertyMetadatas
    {
        get => base.PropertyMetadatas;
        set => base.PropertyMetadatas = value;
    }

    public new string? EntityTitle
    {
        get => base.EntityTitle;
        set => base.EntityTitle = value;
    }

    public new string? KeyPropertyName
    {
        get => base.KeyPropertyName;
        set => base.KeyPropertyName = value;
    }
}