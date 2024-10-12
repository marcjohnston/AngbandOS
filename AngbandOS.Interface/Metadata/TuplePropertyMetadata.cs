namespace AngbandOS.Core.Interface;

public class TuplePropertyMetadata : PropertyMetadata
{
    public TuplePropertyMetadata(string propertyName) : base(propertyName, "tuple") { }
    public PropertyMetadata[] Types
    {
        set
        {
            TupleTypes = value;
        }
    }
}
