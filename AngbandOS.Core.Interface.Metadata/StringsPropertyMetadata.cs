namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents a derived <see cref="PropertyMetadata"/> class for the description of an array of strings property.
/// </summary>
public class StringsPropertyMetadata : PropertyMetadata
{
    public StringsPropertyMetadata(string propertyName) : base("strings", propertyName) { }
    public new string[]? DefaultValue
    {
        get
        {
            if (base.DefaultValue == null)
            {
                return null;
            }
            if (base.DefaultValue.Length == 0)
            {
                throw new Exception("The DefaultValue contains no elements.");
            }
            return DefaultValue;
        }
        set => base.DefaultValue = value;
    }
}