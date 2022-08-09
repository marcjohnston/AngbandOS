using Cthangband.Enumerations;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Enter a store
    /// </summary>
    [Serializable]
    internal class StoreCommand : ICommand
    {
        public char Key => '_';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DoCmdStore(saveGame);
        }

        public static void DoCmdStore(SaveGame saveGame)
        {
            GridTile tile = saveGame.Level.Grid[saveGame.Player.MapY][saveGame.Player.MapX];
            // Make sure we're actually on a shop tile
            if (!tile.FeatureType.IsShop)
            {
                saveGame.MsgPrint("You see no Stores here.");
                return;
            }
            Store which = saveGame.GetWhichStore();
            // We can't enter a house unless we own it
            if (which.StoreType == StoreType.StoreHome && saveGame.Player.TownWithHouse != saveGame.CurTown.Index)
            {
                saveGame.MsgPrint("The door is locked.");
                return;
            }
            // Switch from the normal game interface to the store interface
            saveGame.Level.ForgetLight();
            saveGame.Level.ForgetView();
            Gui.FullScreenOverlay = true;
            Gui.CommandArgument = 0;
            //            CommandRepeat = 0; TODO: Confirm this is not needed
            Gui.QueuedCommand = '\0';
            which.EnterStore(saveGame.Player);
        }
    }
}
