namespace AngbandOS.Core.Interface;

public class TuplePropertyMetadata : PropertyMetadata
{
    public TuplePropertyMetadata(string propertyName) : base(propertyName) { }

    public PropertyMetadata[] Types { get; set; }
}
