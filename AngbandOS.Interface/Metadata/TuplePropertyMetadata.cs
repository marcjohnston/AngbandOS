namespace AngbandOS.Core.Interface;

public class TuplePropertyMetadata : PropertyMetadata
{
    public TuplePropertyMetadata(string propertyName) : base(propertyName) { }
    public virtual PropertyMetadata[] DataTypes { get; set; }
}