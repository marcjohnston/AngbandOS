namespace AngbandOS.Core.Interface;

public class IntegerPropertyMetadata : PropertyMetadata
{
    public IntegerPropertyMetadata(string propertyName) : base(propertyName) { }
    public int? DefaultValue { get; set; }
}