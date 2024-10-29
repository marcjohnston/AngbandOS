namespace AngbandOS.Core.Interface;

public class CharacterPropertyMetadata : PropertyMetadata
{
    public CharacterPropertyMetadata(string propertyName) : base("Character", propertyName) { }
    public char? DefaultValue { get; set; }
}
