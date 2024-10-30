namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents a derived <see cref="PropertyMetadata"/> class for the description of a string property.
/// </summary>
public class StringPropertyMetadata : PropertyMetadata
{
    public StringPropertyMetadata(string propertyName) : base("string", propertyName) { }
    public new string? DefaultValue
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
            return base.DefaultValue[0];
        }
        set => base.DefaultValue = value != null ? new string[] { value } : null;
    }
}
