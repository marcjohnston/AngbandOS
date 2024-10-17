namespace AngbandOS.Core.Interface;

public class ForeignKeyPropertyMetadata : PropertyMetadata
{
    public ForeignKeyPropertyMetadata(string propertyName, string foreignCollectionName) : base(propertyName, "foreign-key")
    {
        base.ForeignCollectionName = foreignCollectionName;
    }
}
