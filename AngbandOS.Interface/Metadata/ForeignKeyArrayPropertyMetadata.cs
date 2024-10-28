namespace AngbandOS.Core.Interface;

public class ForeignKeyArrayPropertyMetadata : PropertyMetadata
{
    public ForeignKeyArrayPropertyMetadata(string propertyName) : base(propertyName) { }
    public string[]? DefaultValue { get; set; }
}