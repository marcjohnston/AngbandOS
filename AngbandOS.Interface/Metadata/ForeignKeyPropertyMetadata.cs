namespace AngbandOS.Core.Interface;

public class ForeignKeyPropertyMetadata : PropertyMetadata
{
    public ForeignKeyPropertyMetadata(string propertyName, string foreignCollection) : base(propertyName, "foreign-key") { }
}

public class ForeignKeyArrayPropertyMetadata : PropertyMetadata
{
    public ForeignKeyArrayPropertyMetadata(string propertyName, string foreignCollection) : base(propertyName, "foreign-key-array") { }
}
