namespace AngbandOS.Core.Interface;

public class ForeignKeyArrayPropertyMetadata : PropertyMetadata
{
    public ForeignKeyArrayPropertyMetadata(string propertyName) : base("Foreign-Key-Array", propertyName) { }
    public string[]? DefaultValue { get; set; }
}