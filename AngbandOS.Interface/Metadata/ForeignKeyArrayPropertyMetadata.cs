namespace AngbandOS.Core.Interface;

public class ForeignKeyArrayPropertyMetadata : PropertyMetadata
{
    public ForeignKeyArrayPropertyMetadata(string propertyName, string foreignCollection) : base(propertyName, "foreign-key-array") { }
}
