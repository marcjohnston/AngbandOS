namespace AngbandOS.Core.Interface;

public class ColorEnumPropertyMetadata : PropertyMetadata
{
    public ColorEnumPropertyMetadata(string propertyName) : base(propertyName) { }
    public ColorEnum? DefaultValue { get; set; }
}
