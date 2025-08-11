// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ColorEnumPropertyValue : PropertyValue
{
    public ColorEnum Value { get; set; }
    public ColorEnumPropertyValue(ColorEnum value)
    {
        Value = value;
    }
    public override PropertyValue Clone() => new ColorEnumPropertyValue(Value);

    public override PropertyValue Merge(PropertyValue itemProperty)
    {
        if (itemProperty is ColorEnumPropertyValue colorEnumPropertyValue)
        {
            return new ColorEnumPropertyValue(colorEnumPropertyValue.Value);
        }
        else if (itemProperty is NullableColorEnumPropertyValue nullableColorEnumPropertyValue)
        {
            return new ColorEnumPropertyValue(nullableColorEnumPropertyValue.Value.HasValue ? nullableColorEnumPropertyValue.Value.Value : Value);
        }
        throw new Exception("Merge mismatch.");
    }

    public override bool IsEqual(PropertyValue itemProperty)
    {
        if (itemProperty is ColorEnumPropertyValue colorEnumPropertyValue)
        {
            return Value == colorEnumPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }
}
