// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class NullableBoolAttributeValue : NullableAttributeValue
{
    public bool? Value { get; }

    public override bool IsSet => Value.HasValue;

    public override AttributeValue Clone() => new NullableBoolAttributeValue(Value);
    public override AttributeValue Merge(AttributeValue itemProperty)
    {
        throw new Exception("Merge mismatch."); // This isn't needed because we will never merge from the nullable version.
    }
    public override bool IsEqual(AttributeValue itemProperty)
    {
        if (itemProperty is NullableBoolAttributeValue nullableBoolPropertyValue)
        {
            return Value == nullableBoolPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }

    public NullableBoolAttributeValue(bool? value)
    {
        Value = value;
    }
}
