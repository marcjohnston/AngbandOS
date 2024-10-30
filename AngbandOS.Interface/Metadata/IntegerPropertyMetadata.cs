namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents a derived <see cref="PropertyMetadata"/> class for the description of an array of integers property.
/// </summary>
public class IntegerPropertyMetadata : PropertyMetadata
{
    public IntegerPropertyMetadata(string propertyName) : base("integer", propertyName) { }
    public new int? DefaultValue
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
            return Int32.Parse(base.DefaultValue[0]);
        }
        set => base.DefaultValue = value.HasValue ? new string[] { value.Value.ToString() } : null;
    }
}