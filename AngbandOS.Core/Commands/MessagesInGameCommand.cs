namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Let the player scroll through previous messages
    /// </summary>
    [Serializable]
    internal class MessagesInGameCommand : InGameCommand
    {
        private MessagesInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'P';

        public override bool Execute()
        {
            SaveGame.DoCmdMessages();
            return false;
        }
    }
}
