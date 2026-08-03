// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class ActivationEffectiveAttributeValue : EffectiveAttributeValue
{
    #region State Data
    /// <summary>
    /// Represents the modifiers that are combined to create the effective value.
    /// </summary>
    protected readonly List<(string Key, Activation? Modifier)> _attributeModifiers = new List<(string, Activation?)>();
    #endregion

    #region Constructors
    public ActivationEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute) { }
    public ActivationEffectiveAttributeValue(Game game, RestoreGameState restoreGameState) : base(game, restoreGameState)
    {
        (string, Activation?)[] modifiers = restoreGameState.GetByKey(nameof(_attributeModifiers)).GetTuples<string, Activation?>(
            _restoreGameState => _restoreGameState.GetString(), 
            _restoreGameState => _restoreGameState.GetDerivedReferenceOrDefault<Activation>());
        _attributeModifiers.AddRange(modifiers);
    }
    #endregion

    public override bool HasKeyedItemEnhancements(string key)
    {
        foreach ((string itemKey, Activation modifier) in _attributeModifiers)
        {
            if (itemKey == key)
            {
                return true;
            }
        }
        return false;
    }

    public Activation? Get()
    {
        if (_attributeModifiers.Count == 0)
        {
            return null;
        }
        return _attributeModifiers[_attributeModifiers.Count - 1].Modifier;
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
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set(Activation? value)
    {
        _attributeModifiers.Add(("", value));
    }

    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(base.Serialize(saveGameState),
            (nameof(_attributeModifiers), saveGameState.CreateTuplesGameStateBag<string, Activation?>(_attributeModifiers.ToArray(), 
                _key => saveGameState.CreateGameStateBag(_key), 
                _modifier => saveGameState.CreateDerivedGameStateBag(_modifier, typeof(Activation))))
        );
    }

    public override string RenderForItemIdentification => Get()?.Description ?? "nothing";
    public override ReadOnlyAttributeValue ToReadOnly() => new ActivationReadOnlyAttributeValue(Get());
    public override EffectiveAttributeValue Clone()
    {
        ActivationEffectiveAttributeValue clone = new ActivationEffectiveAttributeValue(Game, Attribute);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override void Merge(AttributeValue value)
    {
        ActivationReadOnlyAttributeValue setEffectiveAttributeValue = (ActivationReadOnlyAttributeValue)value;
        _attributeModifiers.Add(("", setEffectiveAttributeValue.Value));
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        ActivationReadOnlyAttributeValue setEffectiveAttributeValue = (ActivationReadOnlyAttributeValue)value;
        _attributeModifiers.Add((key, setEffectiveAttributeValue.Value));
    }
}
