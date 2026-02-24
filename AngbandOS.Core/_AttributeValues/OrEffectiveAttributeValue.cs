// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an effective attribute value that combines multiple boolean modifiers using a logical OR operation. The effective value is true if any of the modifiers are true, and false if all modifiers are false.
/// </summary>
[Serializable]
internal class OrEffectiveAttributeValue : EffectiveAttributeValue
{
    /// <summary>
    /// Represents the modifiers that are combined to create the effective value.
    /// </summary>
    private readonly List<(string Key, bool Modifier)> _attributeModifiers = new List<(string, bool)>();

    public OrEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute) { }
    public override string RenderForItemIdentification => Get().ToString();

    public override EffectiveAttributeValue Clone()
    {
        OrEffectiveAttributeValue clone = new OrEffectiveAttributeValue(Game, Attribute);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }

    public override bool HasKeyedItemEnhancements(string key)
    {
        foreach ((string itemKey, bool modifier) in _attributeModifiers)
        {
            if (itemKey == key)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Returns the effective value by applying a logical OR operation across all modifiers. If any modifier is true, the effective value is true; otherwise, it is false.
    /// </summary>
    /// <returns></returns>
    public bool Get()
    {
        foreach ((string key, bool modifier) in _attributeModifiers)
        {
            if (modifier)
            {
                return true;
            }
        }
        return false;
    }

    public override AttributeValue ToReadOnly() => new ReadOnlyAttributeValue<bool>(Get());

    public override void Merge(AttributeValue value)
    {
        ReadOnlyAttributeValue<bool> orEffectiveAttributeValue = (ReadOnlyAttributeValue<bool>)value;
        _attributeModifiers.Add(("", orEffectiveAttributeValue.Value));
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        ReadOnlyAttributeValue<bool> orEffectiveAttributeValue = (ReadOnlyAttributeValue<bool>)value;
        _attributeModifiers.Add((key, orEffectiveAttributeValue.Value));
    }

    public override void RemoveModifiers(string key)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(RemoveModifiers)}");
        }
        _attributeModifiers.RemoveAll((item) => item.Key == key);
    }

    public void Set()
    {
        _attributeModifiers.Add(("", true));
    }
    /// <summary>
    /// Sets the OR attribute, if and only if the parameter is true.  Null and false values have no effect and do not set.
    /// </summary>
    /// <param name="value"></param>
    public void Set(bool? value)
    {
        if (value.HasValue && value.Value)
        {
            Set();
        }
    }
}
