namespace AngbandOS.Core.Interface;

public class BooleanPropertyMetadata : PropertyMetadata
{
    public BooleanPropertyMetadata(string propertyName) : base("boolean", propertyName) { }
    public new bool? DefaultValue
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
            return Boolean.Parse(base.DefaultValue[0]);
        }
        set => base.DefaultValue = value.HasValue ? new string[] { value.Value.ToString().ToLower() } : null;
    }
}