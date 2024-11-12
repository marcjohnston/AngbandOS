namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName) : base("collection", propertyName) { }

    public new PropertyMetadata[]? PropertyMetadatas
    {
        get => base.PropertyMetadatas;
        set => base.PropertyMetadatas = value;
    }

    public new string? EntityNoun
    {
        get => base.EntityNoun;
        set => base.EntityNoun = value;
    }

    public new string? EntityNounTitle
    {
        get => base.EntityNounTitle;
        set => base.EntityNounTitle = value;
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
