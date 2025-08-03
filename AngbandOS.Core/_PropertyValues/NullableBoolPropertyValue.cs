// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class NullableBoolPropertyValue : NullablePropertyValue
{
    public bool? Value { get; set; }

    public override bool IsSet => Value.HasValue;

    public override PropertyValue Clone() => new NullableBoolPropertyValue(Value);
    public override PropertyValue Merge(PropertyValue itemProperty)
    {
        throw new Exception("Merge mismatch."); // This isn't needed because we will never merge from the nullable version.
    }
    public override bool IsEqual(PropertyValue itemProperty)
    {
        if (itemProperty is NullableBoolPropertyValue nullableBoolPropertyValue)
        {
            return Value == nullableBoolPropertyValue.Value;
        }
        throw new Exception("IsEqual mismatch.");
    }

    public override void Reset()
    {
        Value = null;
    }

    public override void Set(PropertyValue propertyValue)
    {
        if (propertyValue is BoolPropertyValue boolPropertyValue)
        {
            Value = boolPropertyValue.Value;
        }
        else
        {
            throw new Exception("Mismatch set.");
        }
    }

    public NullableBoolPropertyValue(bool? value)
    {
        Value = value;
    }
}
