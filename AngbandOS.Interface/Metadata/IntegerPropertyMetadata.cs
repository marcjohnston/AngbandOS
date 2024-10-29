namespace AngbandOS.Core.Interface;

public class IntegerPropertyMetadata : PropertyMetadata
{
    public IntegerPropertyMetadata(string propertyName) : base("Integer", propertyName) { }
    public int? DefaultValue { get; set; }
}