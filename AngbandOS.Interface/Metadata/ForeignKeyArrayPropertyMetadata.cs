namespace AngbandOS.Core.Interface;

public class ForeignKeyArrayPropertyMetadata : PropertyMetadata
{
    public ForeignKeyArrayPropertyMetadata(string propertyName, string foreignCollectionName) : base(propertyName, "foreign-key-array")
    {
        base.ForeignCollectionName = foreignCollectionName;
    }
}
