namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Print the version number and build info of the game
    /// </summary>
    [Serializable]
    internal class VersionInGameCommand : InGameCommand
    {
        private VersionInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'V';

        public override bool Execute()
        {
            SaveGame.DoCmdVersion();
            return false;
        }
    }
}
