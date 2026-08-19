// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class ScriptsListEffectiveAttributeValue : ListEffectiveAttributeValue<UniversalScript>
{
    public ScriptsListEffectiveAttributeValue(Game game, Attribute attribute) : base(game, attribute)
    {
    }
    public ScriptsListEffectiveAttributeValue(Game game, RestoreGameState restoreGameState) : base(game, restoreGameState)
    {
        (string, UniversalScript[])[] modifiers = restoreGameState.GetByKey(nameof(_attributeModifiers)).GetTuples<string, UniversalScript[]>(
            _restoreGameState => _restoreGameState.GetString(), // This is the key
            _restoreGameState => _restoreGameState.GetDerivedReferences<UniversalScript>()); // These are the IScripts (or null).
        _attributeModifiers.AddRange(modifiers);
    }

    protected override string GetDescriptionForItemIdentification(UniversalScript value)
    {
        return value.GetType().Name;
    }
    public override ReadOnlyAttributeValue ToReadOnly() => new ScriptsListReadOnlyAttributeValue(Get());

    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(base.Serialize(saveGameState), // Serialize the base classes
            (nameof(_attributeModifiers), saveGameState.CreateTuplesGameStateBag<string, UniversalScript[]>(_attributeModifiers.ToArray(), // Here is the List, which may be empty but not nullable
                _key => saveGameState.CreateGameStateBag(_key), // Serialize the string key
                _modifiers => saveGameState.CreateDerivedGameStateBag(_modifiers, false))) // Serialize the UniversalScript
        );
    }

    public override EffectiveAttributeValue Clone()
    {
        ScriptsListEffectiveAttributeValue clone = new ScriptsListEffectiveAttributeValue(Game, Attribute);
        clone._attributeModifiers.AddRange(_attributeModifiers);
        return (EffectiveAttributeValue)clone;
    }
}