namespace AngbandOS.Core.Interface;

public class ForeignKeyPropertyMetadata : PropertyMetadata
{
    public ForeignKeyPropertyMetadata(string propertyName) : base("Foreign-Key", propertyName) { }
    public string? DefaultValue { get; set; }
}