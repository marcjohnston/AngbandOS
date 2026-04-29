// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class BoolSetEffectiveAttributeValue : EffectiveAttributeValue
{
    /// <summary>
    /// Represents the modifiers that are combined to create the effective value.
    /// </summary>
    protected readonly List<(string Key, bool? Modifier)> _attributeModifiers = new List<(string, bool?)>();
    protected readonly bool? _initialValue;

    public BoolSetEffectiveAttributeValue(Game game, Attribute attribute, bool? initialValue) : base(game, attribute)
    {
        _initialValue = initialValue;
        _attributeModifiers.Add(("", initialValue));
    }
    public BoolSetEffectiveAttributeValue(Game game, RestoreGameState restoreGameState) : base(game, restoreGameState.GetReference<Attribute>(nameof(Attribute)))
    {
        _initialValue = restoreGameState.GetBoolOrDefault(nameof(_initialValue));
        ListGameStateBag tuplesListGameStateBag = restoreGameState.GetGameStateBag<ListGameStateBag>(nameof(_attributeModifiers));

        // We need to skip the first modifier.  It is preassigned.  TODO: This shouldn't be like this.
        foreach (GameStateBag tupleGameStateBag in tuplesListGameStateBag.Values)
        {
            RestoreGameState tupleRestoreGameState = restoreGameState.New(tupleGameStateBag);
            string key = tupleRestoreGameState.GetString("Key");
            bool? modifier = tupleRestoreGameState.GetBoolOrDefault("Modifier");

            _attributeModifiers.Add((key, modifier));
        }
    }

    public override EffectiveAttributeValue Clone()
    {
        BoolSetEffectiveAttributeValue clone = new BoolSetEffectiveAttributeValue(Game, Attribute, _initialValue);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        // Serialize the tuples.
        GameStateBag[] attributeModifiersGameStateBags = _attributeModifiers.Select(_attributeModifier => new DictionaryGameStateBag(
                (nameof(_attributeModifier.Key), saveGameState.CreateGameStateBag(_attributeModifier.Key)),
                (nameof(_attributeModifier.Modifier), saveGameState.CreateGameStateBag(_attributeModifier.Modifier))
        )).ToArray();

        // Put the dictionary of tuples into a list.
        GameStateBag attributeModifiersListGameStateBag = new ListGameStateBag(attributeModifiersGameStateBags);

        // Return the dictionary of the values.
        return new DictionaryGameStateBag(base.Serialize(saveGameState),
            (nameof(_initialValue), saveGameState.CreateGameStateBag(_initialValue)),
            (nameof(_attributeModifiers), attributeModifiersListGameStateBag)
        );
    }
    public override string RenderForItemIdentification => Get().ToString();
    public override AttributeValue ToReadOnly() => new NullableBoolReadOnlyAttributeValue(Get());

    public override bool HasKeyedItemEnhancements(string key)
    {
        foreach ((string itemKey, bool? modifier) in _attributeModifiers)
        {
            if (itemKey == key)
            {
                return true;
            }
        }
        return false;
    }

    public bool? Get()
    {
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

    public override void Merge(AttributeValue value)
    {
        NullableBoolReadOnlyAttributeValue setEffectiveAttributeValue = (NullableBoolReadOnlyAttributeValue)value;
        _attributeModifiers.Add(("", setEffectiveAttributeValue.Value));
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        NullableBoolReadOnlyAttributeValue setEffectiveAttributeValue = (NullableBoolReadOnlyAttributeValue)value;
        _attributeModifiers.Add((key, setEffectiveAttributeValue.Value));
    }

    /// <summary>
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set(bool value)
    {
        _attributeModifiers.Add(("", value));
    }

    /// <summary>
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set()
    {
        _attributeModifiers.Add(("", true));
    }

    /// <summary>
    /// Appends a false modifier to the list of modifiers--effectively making the attribute value false.
    /// </summary>
    public void Reset()
    {
        _attributeModifiers.Add(("", false));
    }
    public bool IsTrue
    {
        get
        {
            bool? value = Get();
            return value.HasValue && value.Value;
        }
    }
}
