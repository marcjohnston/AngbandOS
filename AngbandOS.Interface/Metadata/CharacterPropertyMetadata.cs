namespace AngbandOS.Core.Interface;

public class CharacterPropertyMetadata : PropertyMetadata
{
    public CharacterPropertyMetadata(string propertyName) : base(propertyName, "character") { }
    public char DefaultValue
    {
        set
        {
            DefaultCharacterValue = value;
        }
    }
}
