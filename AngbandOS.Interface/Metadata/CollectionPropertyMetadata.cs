namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName) : base("Collection", propertyName) { }
    public virtual PropertyMetadata[] PropertyMetadatas { get; set; }

    public virtual string EntityTitle { get; set; }

    public virtual string KeyPropertyName { get; set; }
}