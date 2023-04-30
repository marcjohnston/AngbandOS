namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Display a list of all the keyboard commands
    /// </summary>
    [Serializable]
    internal class CommandListGameCommand : GameCommand
    {
        private CommandListGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '?';

        public override bool Execute()
        {
            SaveGame.DoCmdListCommands();
            return false;
        }
    }
}
