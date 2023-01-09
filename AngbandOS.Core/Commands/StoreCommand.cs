namespace AngbandOS.Commands
{
    /// <summary>
    /// Enter a store
    /// </summary>
    [Serializable]
    internal class StoreCommand : ICommand
    {
        private StoreCommand(SaveGame saveGame) { } // This object is a singleton.

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
            if (which.DoorsLocked(saveGame))
            {
                saveGame.MsgPrint("The door is locked.");
                return;
            }
            // Switch from the normal game interface to the store interface
            saveGame.UpdateRemoveLightFlaggedAction.Check(true);
            saveGame.Level.ForgetView();
            saveGame.FullScreenOverlay = true;
            saveGame.CommandArgument = 0;
            //            CommandRepeat = 0; TODO: Confirm this is not needed
            saveGame.QueuedCommand = '\0';
            which.EnterStore();
        }
    }
}
