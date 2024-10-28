namespace AngbandOS.Core.Interface;

public class StringArrayPropertyMetadata : PropertyMetadata
{
    public StringArrayPropertyMetadata(string propertyName) : base(propertyName) { }
    public string[]? DefaultValue { get; set; }
}