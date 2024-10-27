namespace AngbandOS.Core.Interface;

public class GenericCollectionPropertyMetadata : GenericPropertyMetadata
{
    public virtual IPropertyMetadata[] PropertyMetadatas { get; set; }

    public virtual string EntityTitle { get; set; }

    public virtual string KeyPropertyName => "Key";
}