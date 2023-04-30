namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Let the player scroll through previous messages
    /// </summary>
    [Serializable]
    internal class MessagesGameCommand : GameCommand
    {
        private MessagesGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'P';

        public override bool Execute()
        {
            SaveGame.DoCmdMessages();
            return false;
        }
    }
}
