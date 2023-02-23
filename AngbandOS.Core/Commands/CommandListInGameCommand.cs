namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Display a list of all the keyboard commands
    /// </summary>
    [Serializable]
    internal class CommandListInGameCommand : InGameCommand
    {
        private CommandListInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '?';

        public override bool Execute()
        {
            SaveGame.DoCmdListCommands();
            return false;
        }
    }
}
