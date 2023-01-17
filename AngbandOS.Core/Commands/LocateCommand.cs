namespace AngbandOS.Commands
{
    /// <summary>
    /// Locate the player on the level and let them scroll the map around
    /// </summary>
    [Serializable]
    internal class LocateCommand : Command
    {
        private LocateCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'L';

        public override bool Execute()
        {
            SaveGame.DoCmdLocate();
            return false;
        }
    }
}
