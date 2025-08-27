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
    public bool Value { get; }
    public BoolAttributeValue(AttributeFactory factory, bool value) : base(factory)
    {
        Value = value;
    }

    public override AttributeValue Merge(AttributeValue itemProperty)
    {
        if (itemProperty is BoolAttributeValue boolPropertyValue)
        {
            return new BoolAttributeValue(Factory, Value || boolPropertyValue.Value);
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
    public override string ToString()
    {
        return $"{base.ToString()}={Value}";
    }
}
