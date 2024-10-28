namespace AngbandOS.Core.Interface;

public class CharacterPropertyMetadata : PropertyMetadata
{
    public CharacterPropertyMetadata(string propertyName) : base(propertyName) { }
    public char? DefaultValue { get; set; }
}
