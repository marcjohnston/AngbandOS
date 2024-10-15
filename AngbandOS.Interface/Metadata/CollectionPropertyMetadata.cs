namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName, string keyPropertyName = "Key") : base(propertyName, "collection")
    {
        KeyPropertyName = keyPropertyName;
    }

    public PropertyMetadata[] PropertyMetadatas
    {
        set
        {
            CollectionPropertyMetadatas = value;
        }
    }

    public string EntityTitle
    {
        set
        {
            CollectionEntityTitle = value;
        }
    }

    public string KeyPropertyName
    {
        set
        {
            CollectionKeyPropertyName = value;
        }
    }
}