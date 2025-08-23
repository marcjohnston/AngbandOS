// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class BoolAttributeValue : AttributeValue
{
    public bool Value { get; set; }
    public BoolAttributeValue(bool value)
    {
        Value = value;
    }

    public override AttributeValue Clone() => new BoolAttributeValue(Value);

    public override AttributeValue Merge(AttributeValue itemProperty)
    {
        if (itemProperty is BoolAttributeValue boolPropertyValue)
        {
            return new BoolAttributeValue(Value || boolPropertyValue.Value);
        }
        else if (itemProperty is NullableBoolAttributeValue nullableBoolPropertyValue)
        {
            return new BoolAttributeValue(nullableBoolPropertyValue.Value.HasValue ? nullableBoolPropertyValue.Value.Value : Value);
        }
        throw new Exception("Merge mismatch.");
    }

    public override bool IsEqual(AttributeValue itemProperty)
    {
        if (itemProperty is BoolAttributeValue boolPropertyValue)
        {
            return Value == boolPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }
}
