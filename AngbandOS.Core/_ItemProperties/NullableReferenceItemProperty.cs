// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class NullableReferenceItemProperty<T> : ItemProperty where T : class
{
    public T? Value { get; set; }

    public override ItemProperty Clone()
    {
        return new NullableReferenceItemProperty<T>(Index, Value);
    }

    public override ItemProperty Override(ItemProperty itemProperty)
    {
        // We are only supporting the override from a read-write with a read-only.
        if (itemProperty is NullableReferenceItemProperty<T> nullableReferenceItemProperty)
        {
            return new NullableReferenceItemProperty<T>(Index, Value ?? nullableReferenceItemProperty.Value); // If the override value is not null, then use the incoming value.
        }
        else
        {
            throw new Exception($"The item property override from {itemProperty.GetType().Name} is not supported with {nameof(NullableReferenceItemProperty<T>)}");
        }
    }

    public override bool IsEqual(ItemProperty itemProperty)
    {
        if (itemProperty is NullableReferenceItemProperty<T> roNullableReferenceItemProperty)
        {
            return Value == roNullableReferenceItemProperty.Value;
        }
        else
        {
            throw new Exception($"Item property equality from {itemProperty.GetType().Name} not supported with {nameof(NullableReferenceItemProperty<T>)}");
        }
    }

    public override ItemProperty Merge(ItemProperty itemProperty)
    {
        if (itemProperty is NullableReferenceItemProperty<T> nullableReferenceItemProperty)
        {
            return new NullableReferenceItemProperty<T>(Index, nullableReferenceItemProperty.Value ?? Value);
        }
        else
        {
            throw new Exception($"Item property merging from {itemProperty.GetType().Name} not supported with {nameof(NullableReferenceItemProperty<T>)}");
        }
    }

    public NullableReferenceItemProperty(int index) : base(index)
    {
        Value = default;
    }

    public NullableReferenceItemProperty(int index, T? value) : base(index)
    {
        Value = value;
    }
}
