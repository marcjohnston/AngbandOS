namespace AngbandOS.Core.Interface;

public class ColorEnumPropertyMetadata : PropertyMetadata
{
    public ColorEnumPropertyMetadata(string propertyName) : base("ColorEnum", propertyName) { }
    public ColorEnum? DefaultValue { get; set; }
}
