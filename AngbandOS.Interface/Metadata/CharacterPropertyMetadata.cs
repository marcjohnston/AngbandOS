namespace AngbandOS.Core.Interface;

public class CharacterPropertyMetadata : PropertyMetadata
{
    public CharacterPropertyMetadata(string propertyName) : base("character", propertyName) { }
    public new char? DefaultValue
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
            return Char.Parse(base.DefaultValue[0]);
        }
        set => base.DefaultValue = value.HasValue ? new string[] { value.Value.ToString() } : null;
    }
}
