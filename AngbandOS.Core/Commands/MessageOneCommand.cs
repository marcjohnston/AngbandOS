namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Show the previous message
    /// </summary>
    [Serializable]
    internal class MessageOneCommand : Command
    {
        private MessageOneCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'O';

        public override bool Execute()
        {
            SaveGame.DoCmdMessageOne();
            return false;
        }
    }
}
