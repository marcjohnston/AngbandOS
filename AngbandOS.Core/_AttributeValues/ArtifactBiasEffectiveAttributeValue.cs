// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ArtifactBiasEffectiveAttributeValue : EffectiveAttributeValue
{
    /// <summary>
    /// Represents the modifiers that are combined to create the effective value.
    /// </summary>
    protected readonly List<(string Key, ArtifactBias? Modifier)> _attributeModifiers = new List<(string, ArtifactBias?)>();

    public ArtifactBiasEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute) { }
    public ArtifactBiasEffectiveAttributeValue(Game game, RestoreGameState restoreGameState) : base(game, restoreGameState.GetReference<Attribute>(nameof(Attribute)))
    {
        ListGameStateBag tuplesListGameStateBag = restoreGameState.GetGameStateBag<ListGameStateBag>(nameof(_attributeModifiers));

        foreach (GameStateBag tupleGameStateBag in tuplesListGameStateBag.Values)
        {
            RestoreGameState tupleRestoreGameState = restoreGameState.New(tupleGameStateBag);
            string key = tupleRestoreGameState.GetString("Key");
            ArtifactBias? modifier = tupleRestoreGameState.GetReferenceOrDefault<ArtifactBias>("Modifier");
            _attributeModifiers.Add((key, modifier));
        }
    }
    public override AttributeValue ToReadOnly() => new ArtifactBiasReadOnlyAttributeValue(Get());
    public override bool HasKeyedItemEnhancements(string key)
    {
        foreach ((string itemKey, ArtifactBias modifier) in _attributeModifiers)
        {
            if (itemKey == key)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Computes a value to append to the modifiers so that the effective value equals the specified value.
    /// </summary>
    /// <param name="value"></param>
    public void Set(ArtifactBias? value)
    {
        _attributeModifiers.Add(("", value));
    }
    public ArtifactBias? Get()
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
    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        // Serialize the tuples.
        GameStateBag[] tupleGameStateBags = _attributeModifiers.Select(_attributeModifier => new DictionaryGameStateBag(
                (nameof(_attributeModifier.Key), saveGameState.CreateGameStateBag(_attributeModifier.Key)),
                (nameof(_attributeModifier.Modifier), saveGameState.CreateGameStateBag(_attributeModifier.Modifier))
        )).ToArray();

        // Put the tuples into a list.
        GameStateBag listOfTuplesGameStateBag = new ListGameStateBag(tupleGameStateBags);

        // Return the dictionary of the values.
        return new DictionaryGameStateBag(base.Serialize(saveGameState),
            (nameof(_attributeModifiers), listOfTuplesGameStateBag)
        );
    }
    public override EffectiveAttributeValue Clone()
    {
        ArtifactBiasEffectiveAttributeValue clone = new ArtifactBiasEffectiveAttributeValue(Game, Attribute);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
    public override string RenderForItemIdentification => Get()?.AffinityName.ToLower() ?? "nothing";
    public override void Merge(AttributeValue value)
    {
        ArtifactBiasReadOnlyAttributeValue setEffectiveAttributeValue = (ArtifactBiasReadOnlyAttributeValue)value;
        _attributeModifiers.Add(("", setEffectiveAttributeValue.Value));
    }

    public override void Merge(string key, AttributeValue value)
    {
        if (String.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Invalid key specified for enhancements.");
        }
        ArtifactBiasReadOnlyAttributeValue setEffectiveAttributeValue = (ArtifactBiasReadOnlyAttributeValue)value;
        _attributeModifiers.Add((key, setEffectiveAttributeValue.Value));
    }
}
