namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName) : base("collection", propertyName) { }

    public new PropertyMetadata[]? PropertyMetadatas
    {
        get => base.PropertyMetadatas;
        set => base.PropertyMetadatas = value;
    }

    public new string? EntityName
    {
        get => base.EntityName;
        set => base.EntityName = value;
    }

    public new string? EntityTitle
    {
        get => base.EntityTitle;
        set => base.EntityTitle = value;
    }

    public new string? EntityNamePropertyName
    {
        get => base.EntityNamePropertyName;
        set => base.EntityNamePropertyName = value;
    }

    public new string? EntityKeyPropertyName
    {
        get => base.EntityKeyPropertyName;
        set => base.EntityKeyPropertyName = value;
    }
}
