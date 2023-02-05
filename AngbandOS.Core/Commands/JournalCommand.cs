namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Look in the player's journal for any one of a number of different reasons
    /// </summary>
    [Serializable]
    internal class JournalCommand : Command
    {
        private JournalCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'J';

        public override bool Execute()
        {
            SaveGame.DoCmdJournal();
            return false;
        }
    }
}
