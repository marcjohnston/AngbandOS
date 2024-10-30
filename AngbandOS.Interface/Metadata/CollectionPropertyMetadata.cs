namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName) : base("Collection", propertyName) { }
    public PropertyMetadata[] PropertyMetadatas { get; set; }

    public string EntityTitle { get; set; }

    public string KeyPropertyName { get; set; }
}