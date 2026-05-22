// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
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
    public ActivationEffectiveAttributeValue(Game game, RestoreGameState restoreGameState) : base(game, restoreGameState.GetByKey(nameof(Attribute)).GetReference<Attribute>())
    {
        RestoreGameState listRestoreGameState = restoreGameState.GetByKey(nameof(_attributeModifiers));
        foreach (GameStateBag tupleGameStateBag in ((ListGameStateBag)listRestoreGameState.GameStateBag).Values)
        {
            RestoreGameState tupleRestoreGameState = restoreGameState.New(tupleGameStateBag);
            string key = tupleRestoreGameState.GetByKey("Key").GetString();
            Activation? modifier = tupleRestoreGameState.GetByKey("Modifier").GetReferenceOrDefault<Activation>();

            _attributeModifiers.Add((key, modifier));
        }
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
        // Serialize the tuples.
        GameStateBag[] tupleGameStateBags = _attributeModifiers.Select(_attributeModifier => new DictionaryGameStateBag(
                ("Key", saveGameState.CreateGameStateBag(_attributeModifier.Key)),
                ("Modifier", saveGameState.CreateGameStateBag(_attributeModifier.Modifier))
        )).ToArray();

        // Put the tuples into a list.
        GameStateBag listOfTuplesGameStateBag = new ListGameStateBag(tupleGameStateBags);

        // Return the dictionary of the values.
        return new DictionaryGameStateBag(base.Serialize(saveGameState),
            (nameof(_attributeModifiers), listOfTuplesGameStateBag)
        );
    }

    public override string RenderForItemIdentification => Get()?.Description ?? "nothing";
    public override AttributeValue ToReadOnly() => new ActivationReadOnlyAttributeValue(Get());
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
