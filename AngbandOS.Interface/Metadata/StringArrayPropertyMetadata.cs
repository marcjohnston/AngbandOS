namespace AngbandOS.Core.Interface;

public class StringArrayPropertyMetadata : PropertyMetadata
{
    public StringArrayPropertyMetadata(string propertyName) : base(propertyName, "string-array") { }
    public string[] DefaultValue
    {
        set
        {
            DefaultStringArrayValue = value;
        }
    }
}
