// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

internal class CombinedArmorClassIntFunction : IChangeTracker, IGetKey, IIntValue, ISaveGameState
{
    private Game Game { get; }
    private int? OldValue = null;
    private CombinedArmorClassIntFunction(Game game)
    {
        Game = game;
    }

    public bool IsChanged => !OldValue.HasValue || OldValue.Value != Game.BaseArmorClass + Game.KnownBonusArmorClass;
    public string GetKey => GetType().Name;

    public int IntValue => Game.BaseArmorClass + Game.KnownBonusArmorClass;

    public void Bind() { }
    public void RestoreGame(RestoreGameState restoreGameState) 
    { 
        OldValue = restoreGameState.GetByKey(nameof(OldValue)).GetNullableInt();
    }
    public void InitializationComplete() { }

    public void ClearChangedFlag()
    {
        OldValue = IntValue;
    }

    public GameStateBag? SaveGame(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(OldValue), saveGameState.CreateGameStateBag(OldValue))
        );
    }
}
