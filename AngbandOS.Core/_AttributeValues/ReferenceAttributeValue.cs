// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ReferenceAttributeValue<T> : AttributeValue where T : class
{
    public T? Value { get; }

    public override AttributeValue Clone() => new ReferenceAttributeValue<T>(Factory, Value);

    public override bool IsEqual(AttributeValue itemProperty)
    {
        if (itemProperty is ReferenceAttributeValue<T> roNullableReferenceItemProperty)
        {
            return Value == roNullableReferenceItemProperty.Value;
        }
        else
        {
            throw new Exception($"Item property equality from {itemProperty.GetType().Name} not supported with {nameof(ReferenceAttributeValue<T>)}");
        }
    }

    public override AttributeValue Merge(AttributeValue propertyValue)
    {
        if (propertyValue is ReferenceAttributeValue<T> nullableReferencePropertyValue)
        {
            return new ReferenceAttributeValue<T>(Factory, nullableReferencePropertyValue.Value ?? Value);
        }
        throw new Exception($"Item property merging from {propertyValue.GetType().Name} not supported with {nameof(ReferenceAttributeValue<T>)}");
    }

    public ReferenceAttributeValue(AttributeFactory factory, T? value) : base(factory)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"{base.ToString()}={Value}";
    }
}
