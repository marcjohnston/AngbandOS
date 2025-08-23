// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ColorEnumAttributeValue : AttributeValue
{
    public ColorEnum Value { get; }
    public ColorEnumAttributeValue(ColorEnum value)
    {
        Value = value;
    }
    public override AttributeValue Clone() => new ColorEnumAttributeValue(Value);

    public override AttributeValue Merge(AttributeValue itemProperty)
    {
        if (itemProperty is ColorEnumAttributeValue colorEnumPropertyValue)
        {
            return new ColorEnumAttributeValue(colorEnumPropertyValue.Value);
        }
        else if (itemProperty is NullableColorEnumPropertyValue nullableColorEnumPropertyValue)
        {
            return new ColorEnumAttributeValue(nullableColorEnumPropertyValue.Value.HasValue ? nullableColorEnumPropertyValue.Value.Value : Value);
        }
        throw new Exception("Merge mismatch.");
    }

    public override bool IsEqual(AttributeValue itemProperty)
    {
        if (itemProperty is ColorEnumAttributeValue colorEnumPropertyValue)
        {
            return Value == colorEnumPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }
}
