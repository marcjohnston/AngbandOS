// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class NullableReferenceAttributeValue<T> : AttributeValue where T : class
{
    public T? Value { get; }

    public override bool IsEqual(AttributeValue attributeValue)
    {
        if (attributeValue is not NullableReferenceAttributeValue<T> roNullableReferenceItemProperty)
        {
            throw new Exception($"Item property equality from {attributeValue.GetType().Name} not supported with {nameof(NullableReferenceAttributeValue<T>)}");
        }
        return Value == roNullableReferenceItemProperty.Value;
    }

    public override AttributeValue Merge(AttributeValue attributeValue)
    {
        if (attributeValue is null)
        {
            return this;
        }
        if (attributeValue is NullableReferenceAttributeValue<T> nullableReferencePropertyValue)
        {
            return new NullableReferenceAttributeValue<T>(Factory, nullableReferencePropertyValue.Value ?? Value);
        }
        throw new Exception($"Item property merging from {attributeValue.GetType().Name} not supported with {nameof(NullableReferenceAttributeValue<T>)}");
    }

    public NullableReferenceAttributeValue(AttributeFactory factory, T? value) : base(factory)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"{base.ToString()}={Value}";
    }
}
