namespace AngbandOS.Core.Interface;

public class ForeignKeysPropertyMetadata : PropertyMetadata
{
    public ForeignKeysPropertyMetadata(string propertyName) : base("foreign-keys", propertyName) { }
    public new string? ForeignCollectionName
    {
        get => base.ForeignCollectionName;
        set => base.ForeignCollectionName = value;
    }
}