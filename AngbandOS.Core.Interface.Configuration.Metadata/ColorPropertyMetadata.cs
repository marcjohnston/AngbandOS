namespace AngbandOS.Core.Interface;

public class ColorPropertyMetadata : PropertyMetadata
{
    public ColorPropertyMetadata(string propertyName) : base("color", propertyName) { }
    public new ColorEnum? DefaultValue
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
            return Enum.Parse<ColorEnum>(base.DefaultValue[0]);
        }
        set
        {
            if (value.HasValue)
            {
                string? colorName = Enum.GetName<ColorEnum>(value.Value);
                if (colorName == null)
                {
                    throw new Exception("Invalid color enum specified.");
                }
                base.DefaultValue = value.HasValue ? new string[] { colorName } : null;
            }
            else
            {
                base.DefaultValue = null;
            }
        }
    }
}
