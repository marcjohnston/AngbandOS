// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class SetEffectiveAttributeValue<T> : EffectiveAttributeValue
{
    /// <summary>
    /// Represents the modifiers that are combined to create the effective value.
    /// </summary>
    protected readonly List<(string Key, T Modifier)> _attributeModifiers = new List<(string, T)>();
    protected readonly T InitialValue;

    public SetEffectiveAttributeValue(Game game, Attribute attribute, T initialValue) : base(game, attribute)
    {
        InitialValue = initialValue;
        _attributeModifiers.Add(("", initialValue));
    }

    public override bool HasKeyedItemEnhancements(string key)
    {
        foreach ((string itemKey, T modifier) in _attributeModifiers)
        {
            if (itemKey == key)
            {
                return true;
            }
        }
        return false;
    }

    public T Get()
    {
        return _attributeModifiers[_attributeModifiers.Count - 1].Modifier;
    }

    public override AttributeValue ToReadOnly() => new ReadOnlyAttributeValue<T>(Get());
    public override void Merge(AttributeValue value)
    {
        ReadOnlyAttributeValue<T> setEffectiveAttributeValue = (ReadOnlyAttributeValue<T>)value;
        _attributeModifiers.Add(("", setEffectiveAttributeValue.Value));
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        ReadOnlyAttributeValue<T> setEffectiveAttributeValue = (ReadOnlyAttributeValue<T>)value;
        _attributeModifiers.Add((key, setEffectiveAttributeValue.Value));
    }

    public override void RemoveModifiers(string key)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(RemoveModifiers)}");
        }
        _attributeModifiers.RemoveAll((item) => item.Key == key);
    }
}
