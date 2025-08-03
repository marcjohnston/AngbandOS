// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class NullableReferencePropertyValue<T> : NullablePropertyValue where T : class
{
    public T? Value { get; set; }

    public override bool IsSet => Value is not null;

    public override PropertyValue Clone() => new NullableReferencePropertyValue<T>(Value);

    public override bool IsEqual(PropertyValue itemProperty)
    {
        if (itemProperty is NullableReferencePropertyValue<T> roNullableReferenceItemProperty)
        {
            return Value == roNullableReferenceItemProperty.Value;
        }
        else
        {
            throw new Exception($"Item property equality from {itemProperty.GetType().Name} not supported with {nameof(NullableReferencePropertyValue<T>)}");
        }
    }

    public override PropertyValue Merge(PropertyValue propertyValue)
    {
        if (propertyValue is NullableReferencePropertyValue<T> nullableReferencePropertyValue)
        {
            return new NullableReferencePropertyValue<T>(nullableReferencePropertyValue.Value ?? Value);
        }
        throw new Exception($"Item property merging from {propertyValue.GetType().Name} not supported with {nameof(NullableReferencePropertyValue<T>)}");
    }

    public override void Reset()
    {
        Value = null;
    }

    public override void Set(PropertyValue propertyValue)
    {
        if (propertyValue is NullableReferencePropertyValue<T> nullableReferencePropertyValue)
        {
            Value = nullableReferencePropertyValue.Value;
        }
        else
        {
            throw new Exception("Mismatch set.");
        }
    }

    public NullableReferencePropertyValue(T? value)
    {
        Value = value;
    }
}
