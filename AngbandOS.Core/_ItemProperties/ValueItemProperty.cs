// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class ValueItemProperty<T> : ItemProperty where T : struct
{
    public T Value { get; set; }

    public override ItemProperty Clone()
    {
        return new ValueItemProperty<T>(Index, Value);
    }

    public override ItemProperty Override(ItemProperty itemProperty)
    {
        throw new Exception($"The item property override from {itemProperty.GetType().Name} is not supported with {nameof(ValueItemProperty<T>)}");
    }

    public override bool IsEqual(ItemProperty itemProperty)
    {
        if (itemProperty is ValueItemProperty<T> roValueItemProperty)
        {
            return Value.Equals(roValueItemProperty.Value);
        }
        else
        {
            throw new Exception($"Item property equality from {itemProperty.GetType().Name} not supported with {nameof(ValueItemProperty<T>)}");
        }
    }

    public override ItemProperty Merge(ItemProperty itemProperty)
    {
        if (Value is bool boolValue && itemProperty is ValueItemProperty<bool> boolRoValueItemProperty)
        {
            return new ValueItemProperty<bool>(Index, boolValue | boolRoValueItemProperty.Value);
        }
        else if (Value is int intValue && itemProperty is ValueItemProperty<int> intRoValueItemProperty)
        {
            return new ValueItemProperty<int>(Index, intValue + intRoValueItemProperty.Value);
        }
        else
        {
            throw new Exception($"Item property merging from {itemProperty.GetType().Name} is not supported with {nameof(ValueItemProperty<T>)}");
        }
    }

    public ValueItemProperty(int index) : base(index)
    {
        Value = default;
    }

    public ValueItemProperty(int index, T value) : base(index)
    {
        Value = value;
    }
}
