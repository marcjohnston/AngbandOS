namespace AngbandOS.Core.Interface;

public class TupleArrayPropertyMetadata : PropertyMetadata
{
    public TupleArrayPropertyMetadata(string propertyName) : base(propertyName, "tuple-array") { }
    public PropertyMetadata[] Types
    {
        set
        {
            TupleTypes = value;
        }
    }
}
