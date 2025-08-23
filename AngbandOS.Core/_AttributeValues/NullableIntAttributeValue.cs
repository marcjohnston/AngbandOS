// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class NullableIntAttributeValue : NullableAttributeValue
{
    public int? Value { get; }

    public override bool IsSet => Value.HasValue;

    public override AttributeValue Clone() => new NullableIntAttributeValue(Value);
    public override AttributeValue Merge(AttributeValue itemProperty)
    {
        throw new Exception("Merge mismatch."); // This isn't needed because we will never merge from the nullable version.
    }
    public override bool IsEqual(AttributeValue itemProperty)
    {
        if (itemProperty is NullableIntAttributeValue nullableIntPropertyValue)
        {
            return Value == nullableIntPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }

    public NullableIntAttributeValue(int? value)
    {
        Value = value;
    }
}

[Serializable]
internal class NullableColorEnumPropertyValue : NullableAttributeValue
{
    public ColorEnum? Value { get; set; }

    public override bool IsSet => Value.HasValue;

    public override AttributeValue Clone() => new NullableColorEnumPropertyValue(Value);
    public override AttributeValue Merge(AttributeValue itemProperty)
    {
        throw new Exception("Merge mismatch."); // This isn't needed because we will never merge from the nullable version.
    }
    public override bool IsEqual(AttributeValue itemProperty)
    {
        if (itemProperty is NullableColorEnumPropertyValue nullableColorEnumPropertyValue)
        {
            return Value == nullableColorEnumPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }

    public NullableColorEnumPropertyValue(ColorEnum? value)
    {
        Value = value;
    }
}