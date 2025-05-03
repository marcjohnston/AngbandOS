// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class NullableValueItemProperty<T> : ItemProperty where T : struct
{
    public T? Value { get; set; }

    public override ItemProperty Clone()
    {
        return new NullableValueItemProperty<T>(Index, Value);
    }

    public override ItemProperty Override(ItemProperty itemProperty)
    {
        // We are only supporting the override from a read-write with a read-only.
        if (itemProperty is ValueItemProperty<T> valueItemProperty)
        {
            return new ValueItemProperty<T>(Index, Value.HasValue ? Value.Value : valueItemProperty.Value); // If the override value does not have a value, then use the incoming value.
        }
        else
        {
            throw new Exception($"The item property override from {itemProperty.GetType().Name} is not supported with {nameof(NullableValueItemProperty<T>)}");
        }
    }

    public override bool IsEqual(ItemProperty itemProperty)
    {
        if (itemProperty is NullableValueItemProperty<T> roNullableValueItemProperty)
        {
            return Value.Equals(roNullableValueItemProperty.Value);
        }
        else
        {
            throw new Exception($"Item property equality from {itemProperty.GetType().Name} not supported with {nameof(NullableValueItemProperty<T>)}");
        }
    }

    public override ItemProperty Merge(ItemProperty itemProperty)
    {
        // Detect which type of item property we are merging with.
        switch (itemProperty)
        {
            case NullableValueItemProperty<T> nullableValueItemProperty:
                return new NullableValueItemProperty<T>(Index, nullableValueItemProperty.Value ?? Value);
            default:
                throw new Exception($"Item property merging from {itemProperty.GetType().Name} not supported with {nameof(NullableValueItemProperty<T>)}");
        }
    }

    public NullableValueItemProperty(int index) : base(index)
    {
        Value = default;
    }

    public NullableValueItemProperty(int index, T? value) : base(index)
    {
        Value = value;
    }
}
