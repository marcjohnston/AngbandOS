// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnterStoreScript : Script, IScript, IRepeatableScript
{
    private EnterStoreScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the enter store script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the enter store script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        GridTile tile = SaveGame.Grid[SaveGame.MapY][SaveGame.MapX];
        // Make sure we're actually on a shop tile
        if (!tile.FeatureType.IsShop)
        {
            SaveGame.MsgPrint("You see no Stores here.");
            return;
        }
        Store which = SaveGame.GetWhichStore();
        // We can't enter a house unless we own it
        if (which.DoorsLocked())
        {
            SaveGame.MsgPrint("The door is locked.");
            return;
        }
        // Switch from the normal game interface to the store interface
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RemoveLightFlaggedAction)).Check(true);
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RemoveViewFlaggedAction)).Check(true);
        SaveGame.FullScreenOverlay = true;
        SaveGame.CommandArgument = 0;
        //            CommandRepeat = 0; TODO: Confirm this is not needed
        SaveGame.QueuedCommand = '\0';
        which.EnterStore();
    }
}
