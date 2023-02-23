namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Browse a book
    /// </summary>
    [Serializable]
    internal class BrowseInGameCommand : InGameCommand
    {
        private BrowseInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'b';

        public override bool Execute()
        {
            SaveGame.DoCmdBrowse();
            return false;
        }
    }
}
