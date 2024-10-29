namespace AngbandOS.Core.Interface;

public class BooleanPropertyMetadata : PropertyMetadata
{
    public BooleanPropertyMetadata(string propertyName) : base("Boolean", propertyName) { }
    public bool? DefaultValue { get; set; }
}