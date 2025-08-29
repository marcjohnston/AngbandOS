// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class IntAttributeValue : AttributeValue
{
    public int Value { get; }
    public IntAttributeValue(AttributeFactory factory, int value) : base(factory)
    {
        Value = value;
    }
    public override AttributeValue Merge(AttributeValue itemProperty)
    {
        if (itemProperty is not IntAttributeValue intPropertyValue)
        {
            throw new Exception("Merge mismatch.");
        }
        return new IntAttributeValue(Factory, Value + intPropertyValue.Value);
    }

    public override bool IsEqual(AttributeValue itemProperty)
    {
        if (itemProperty is not IntAttributeValue intPropertyValue)
        {
            throw new Exception("IsEqual mismatch.");
        }
        return Value == intPropertyValue.Value;
    }
    public override string DebugDescription => $"{base.ToString()}={Value}";
}
