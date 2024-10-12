namespace AngbandOS.Core.Interface;

public class BooleanPropertyMetadata : PropertyMetadata
{
    public BooleanPropertyMetadata(string propertyName) : base(propertyName, "boolean") { }
    public bool DefaultValue
    {
        set
        {
            DefaultBooleanValue = value;
        }
    }
}
