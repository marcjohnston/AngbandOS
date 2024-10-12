namespace AngbandOS.Core.Interface;

public class IntegerPropertyMetadata : PropertyMetadata
{
    public IntegerPropertyMetadata(string propertyName) : base(propertyName, "integer") { }
    public int DefaultValue
    {
        set
        {
            DefaultIntegerValue = value;
        }
    }
}
