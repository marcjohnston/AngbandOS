namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName) : base(propertyName, "collection") { }

    public PropertyMetadata[] PropertiesMetadata
    {
        set
        {
            CollectionPropertiesMetadata = value;
        }
    }
}