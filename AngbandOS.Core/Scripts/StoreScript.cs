// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class StoreScript : Script
{
    private StoreScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        GridTile tile = SaveGame.Level.Grid[SaveGame.MapY][SaveGame.MapX];
        // Make sure we're actually on a shop tile
        if (!tile.FeatureType.IsShop)
        {
            SaveGame.MsgPrint("You see no Stores here.");
            return false;
        }
        Store which = SaveGame.GetWhichStore();
        // We can't enter a house unless we own it
        if (which.DoorsLocked(SaveGame))
        {
            SaveGame.MsgPrint("The door is locked.");
            return false;
        }
        // Switch from the normal game interface to the store interface
        SaveGame.RemoveLightFlaggedAction.Check(true);
        SaveGame.RemoveViewFlaggedAction.Check(true);
        SaveGame.FullScreenOverlay = true;
        SaveGame.CommandArgument = 0;
        //            CommandRepeat = 0; TODO: Confirm this is not needed
        SaveGame.QueuedCommand = '\0';
        which.EnterStore();
        return false;
    }
}
