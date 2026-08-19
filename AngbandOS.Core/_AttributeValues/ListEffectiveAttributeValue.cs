// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an effective attribute value list.  The value is a list of non-null objects (T).  A single key can have multiple values.  (e.g. "FixedArtifact" has two activations).  This allows a single item to have multiple.
/// activations.
/// </summary>
/// <typeparam name="T"></typeparam>
internal abstract class ListEffectiveAttributeValue<T> : EffectiveAttributeValue where T : notnull
{
    #region State Data
    /// <summary>
    /// Represents the modifiers that are combined to create the effective value.
    /// </summary>
    protected readonly List<(string Key, T[] Modifier)> _attributeModifiers = new List<(string, T[])>();
    #endregion

    #region Constructors
    public ListEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute) { }
    public ListEffectiveAttributeValue(Game game, RestoreGameState restoreGameState) : base(game, restoreGameState)
    {
    }
    #endregion

    public override bool HasKeyedItemEnhancements(string key)
    {
        return _attributeModifiers.Any(m => m.Key == key);
    }

    public T[]? Get()
    {
        if (_attributeModifiers.Count == 0)
        {
            return null;
        }
        return _attributeModifiers.SelectMany(_item => _item.Modifier).ToArray();
    }

    public override void RemoveModifiers(string key)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception($"Cannot specify a blank or null key for {nameof(RemoveModifiers)}");
        }
        _attributeModifiers.RemoveAll((item) => item.Key == key);
    }

    /// <summary>
    /// Returns a description for each value.  Since the value types are generic, the description for the value varies and must be provided by the derived object based
    /// on the type.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    protected abstract string GetDescriptionForItemIdentification(T value);

    public override string[] RenderForItemIdentification => _attributeModifiers.SelectMany(_item => _item.Modifier.Select(_item => GetDescriptionForItemIdentification(_item))).ToArray();

    public override void Merge(AttributeValue value)
    {
        PrivateMerge("", value);
    }

    private void PrivateMerge(string key, AttributeValue value)
    {
        ListReadOnlyAttributeValue<T> setEffectiveAttributeValue = (ListReadOnlyAttributeValue<T>)value;
        if (setEffectiveAttributeValue.Value is not null)
        {
            _attributeModifiers.Add((key, setEffectiveAttributeValue.Value));
        }
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        PrivateMerge(key, value);
    }
}
