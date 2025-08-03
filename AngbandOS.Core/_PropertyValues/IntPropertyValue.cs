// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class IntPropertyValue : PropertyValue
{
    public int Value { get; set; }
    public IntPropertyValue(int value)
    {
        Value = value;
    }
    public override PropertyValue Clone() => new IntPropertyValue(Value);

    public override PropertyValue Merge(PropertyValue itemProperty)
    {
        if (itemProperty is IntPropertyValue intPropertyValue)
        {
            return new IntPropertyValue(Value + intPropertyValue.Value);
        }
        else if (itemProperty is NullableIntPropertyValue nullableIntPropertyValue)
        {
            return new IntPropertyValue(nullableIntPropertyValue.Value.HasValue ? nullableIntPropertyValue.Value.Value : Value);
        }
        throw new Exception("Merge mismatch.");
    }

    public override bool IsEqual(PropertyValue itemProperty)
    {
        if (itemProperty is IntPropertyValue intPropertyValue)
        {
            return Value == intPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }
}
