// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class NullableReferenceAttributeValue<T> : NullableAttributeValue where T : class
{
    public T? Value { get; set; }

    public override bool IsSet => Value is not null;

    public override AttributeValue Clone() => new NullableReferenceAttributeValue<T>(Value);

    public override bool IsEqual(AttributeValue itemProperty)
    {
        if (itemProperty is NullableReferenceAttributeValue<T> roNullableReferenceItemProperty)
        {
            return Value == roNullableReferenceItemProperty.Value;
        }
        else
        {
            throw new Exception($"Item property equality from {itemProperty.GetType().Name} not supported with {nameof(NullableReferenceAttributeValue<T>)}");
        }
    }

    public override AttributeValue Merge(AttributeValue propertyValue)
    {
        if (propertyValue is NullableReferenceAttributeValue<T> nullableReferencePropertyValue)
        {
            return new NullableReferenceAttributeValue<T>(nullableReferencePropertyValue.Value ?? Value);
        }
        throw new Exception($"Item property merging from {propertyValue.GetType().Name} not supported with {nameof(NullableReferenceAttributeValue<T>)}");
    }

    public override void Set(AttributeValue? propertyValue)
    {
        if (propertyValue is null)
        {
            Value = null;
        }
        else if (propertyValue is NullableReferenceAttributeValue<T> nullableReferencePropertyValue)
        {
            Value = nullableReferencePropertyValue.Value;
        }
        else
        {
            throw new Exception("Mismatch set.");
        }
    }

    public NullableReferenceAttributeValue(T? value)
    {
        Value = value;
    }
}
