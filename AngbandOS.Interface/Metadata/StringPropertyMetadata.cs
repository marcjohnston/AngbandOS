namespace AngbandOS.Core.Interface;

public class StringPropertyMetadata : PropertyMetadata
{
    public StringPropertyMetadata(string propertyName) : base("String", propertyName) { }
    public string? DefaultValue { get; set; }
}
