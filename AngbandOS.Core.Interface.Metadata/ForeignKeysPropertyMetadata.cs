namespace AngbandOS.Core.Interface;

public class ForeignKeysPropertyMetadata : PropertyMetadata
{
    public ForeignKeysPropertyMetadata(string propertyName) : base("foreign-keys", propertyName) { }
    public new string? ForeignCollectionName
    {
        get => base.ForeignCollectionName;
        set => base.ForeignCollectionName = value;
    }

    public new bool? Inline
    {
        get => base.Inline;
        set => base.Inline = value;
    }
}