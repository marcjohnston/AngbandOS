// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ArtifactBiasEffectiveAttributeValue : NullableReferenceSetEffectiveAttributeValue<ArtifactBias>
{
    public ArtifactBiasEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute, null) { }
    public ArtifactBiasEffectiveAttributeValue(Game game, RestoreGameState restoreGameState) : base(game, restoreGameState.GetReference<Attribute>(nameof(Attribute)), restoreGameState.GetReferenceOrDefault<ArtifactBias>(nameof(InitialValue))) { }
    public override AttributeValue ToReadOnly() => new ArtifactBiasReadOnlyAttributeValue(Get());
    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        // Serialize the tuples.
        GameStateBag[] tupleGameStateBags = _attributeModifiers.Select(_attributeModifier => new DictionaryGameStateBag(
                (nameof(_attributeModifier.Key), saveGameState.CreateGameStateBag(_attributeModifier.Key)),
                (nameof(_attributeModifier.Modifier), saveGameState.CreateGameStateBag(_attributeModifier.Modifier)),
                (nameof(InitialValue), saveGameState.CreateGameStateBag(InitialValue))
        )).ToArray();

        // Put the tuples into a list.
        GameStateBag listOfTuplesGameStateBag = new ListGameStateBag(tupleGameStateBags);

        // Return the dictionary of the values.
        return new DictionaryGameStateBag(base.Serialize(saveGameState),
            (nameof(InitialValue), saveGameState.CreateGameStateBag(InitialValue)),
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
