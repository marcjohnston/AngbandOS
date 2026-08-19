// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class UniversalScriptListReadOnlyAttributeValue : ListReadOnlyAttributeValue<UniversalScript>
{
    public UniversalScriptListReadOnlyAttributeValue(UniversalScript[]? value) : base(value) { }

    public UniversalScriptListReadOnlyAttributeValue(Game game, RestoreGameState restoreGameState) : base(restoreGameState.GetByKey(nameof(Value)).GetDerivedReferencesOrDefault<UniversalScript>())
    {
    }

    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Value), saveGameState.CreateDerivedGameStateBag(Value, false))
        );
    }
}
