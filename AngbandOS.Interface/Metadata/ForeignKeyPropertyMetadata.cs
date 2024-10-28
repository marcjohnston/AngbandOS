namespace AngbandOS.Core.Interface;

public class ForeignKeyPropertyMetadata : PropertyMetadata
{
    public ForeignKeyPropertyMetadata(string propertyName) : base(propertyName) { }
    public string? DefaultValue { get; set; }
}