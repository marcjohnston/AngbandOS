// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class StayScript : Script, IScript, IRepeatableScript
{
    private StayScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the stay script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the stay script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Standing still takes a turn
        SaveGame.EnergyUse = 100;

        // Periodically search if we're not actively in search mode
        if (SaveGame.IsSearching || SaveGame.SkillSearchFrequency >= 50 || SaveGame.RandomLessThan(50 - SaveGame.SkillSearchFrequency) == 0)
        {
            SaveGame.RunScript(nameof(SearchScript));
        }

        // Pick up items if we should
        SaveGame.StepOnGrid(false);

        // If we're in a shop doorway, enter the shop
        GridTile tile = SaveGame.Grid[SaveGame.MapY][SaveGame.MapX];
        if (tile.FeatureType.IsShop)
        {
            SaveGame.Disturb(false);
            SaveGame._artificialKeyBuffer += SaveGame.SingletonRepository.GameCommands.Get(nameof(EnterStoreGameCommand)).KeyChar;
        }
    }
}
