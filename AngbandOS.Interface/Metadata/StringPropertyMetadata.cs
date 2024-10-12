namespace AngbandOS.Core.Interface;

public class StringPropertyMetadata : PropertyMetadata
{
    public StringPropertyMetadata(string propertyName) : base(propertyName, "string") { }
    public string DefaultValue
    {
        set
        {
            DefaultStringValue = value;
        }
    }
}
