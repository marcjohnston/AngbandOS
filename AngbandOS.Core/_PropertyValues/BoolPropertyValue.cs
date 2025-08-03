// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class BoolPropertyValue : PropertyValue
{
    public bool Value { get; set; }
    public BoolPropertyValue(bool value)
    {
        Value = value;
    }

    public override PropertyValue Clone() => new BoolPropertyValue(Value);

    public override PropertyValue Merge(PropertyValue itemProperty)
    {
        if (itemProperty is BoolPropertyValue boolPropertyValue)
        {
            return new BoolPropertyValue(Value || boolPropertyValue.Value);
        }
        else if (itemProperty is NullableBoolPropertyValue nullableBoolPropertyValue)
        {
            return new BoolPropertyValue(nullableBoolPropertyValue.Value.HasValue ? nullableBoolPropertyValue.Value.Value : Value);
        }
        throw new Exception("Merge mismatch.");
    }

    public override bool IsEqual(PropertyValue itemProperty)
    {
        if (itemProperty is BoolPropertyValue boolPropertyValue)
        {
            return Value == boolPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }
}
