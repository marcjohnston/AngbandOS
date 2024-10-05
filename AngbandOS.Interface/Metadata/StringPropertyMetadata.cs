namespace AngbandOS.Core.Interface;

public class StringPropertyMetadata : PropertyMetadata
{
    public StringPropertyMetadata(string propertyName) : base(propertyName) { }
    public string DefaultValue { get; set; }
}
