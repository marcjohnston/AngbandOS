namespace AngbandOS.Core.Interface;

public class CollectionPropertyMetadata : PropertyMetadata
{
    public CollectionPropertyMetadata(string propertyName) : base(propertyName) { }

    public PropertyMetadata[] PropertiesMetadata { get; set; }
}