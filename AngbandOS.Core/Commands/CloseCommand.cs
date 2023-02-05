namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Close a door
    /// </summary>
    [Serializable]
    internal class CloseCommand : Command
    {
        private CloseCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'c';

        /// <summary>
        /// The close door command is repeatable, until the door is closed.
        /// </summary>
        public override int? Repeat => 99;

        public override bool Execute()
        {
            return SaveGame.DoCmdClose();
        }
    }
}
