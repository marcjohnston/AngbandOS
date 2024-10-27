namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public virtual PropertyMetadata[] PropertyMetadatas { get; set; }

    public virtual string EntityTitle { get; set; }

    public virtual string KeyPropertyName => "Key";
}