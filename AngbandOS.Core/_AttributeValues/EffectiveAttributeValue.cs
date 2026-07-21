// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an effective attribute value with derived classes that implement various algorithms for combining multiple modifiers into a single effective value.
/// </summary>
internal abstract class EffectiveAttributeValue : AttributeValue
{
    #region State Date
    protected readonly Attribute Attribute;
    #endregion

    protected Game Game { get; }
    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Attribute), saveGameState.CreateDerivedGameStateBag(Attribute, false)) //, typeof(ActivationAttribute), typeof(ArtifactBiasAttribute), typeof(FriendlyNameAttribute), typeof(BoolAttribute), typeof(OrAttribute), typeof(SumAttribute)))
        );
    }
    public EffectiveAttributeValue(Game game, Attribute attribute)
    {
        Game = game;
        Attribute = attribute;
    }
    public EffectiveAttributeValue(Game game, RestoreGameState restoreGameState)
    {
        Game = game;
        Attribute = restoreGameState.GetByKey(nameof(Attribute)).GetDerivedReference<Attribute>();
    }

    public abstract string RenderForItemIdentification { get; }
    public abstract EffectiveAttributeValue Clone();

    public abstract ReadOnlyAttributeValue ToReadOnly();
    public abstract void Merge(AttributeValue value);
    public abstract void Merge(string key, AttributeValue value);

    public abstract bool HasKeyedItemEnhancements(string key);

    /// <summary>
    /// Removes all modifiers associated with the specified key.
    /// </summary>
    /// <param name="key"></param>
    public abstract void RemoveModifiers(string key);
}
