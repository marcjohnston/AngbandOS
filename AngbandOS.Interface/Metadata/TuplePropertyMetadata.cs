namespace AngbandOS.Core.Interface;

public class TuplePropertyMetadata : PropertyMetadata
{
    public TuplePropertyMetadata(string propertyName) : base("Tuple", propertyName) { }
    public PropertyMetadata[] DataTypes { get; set; }
}