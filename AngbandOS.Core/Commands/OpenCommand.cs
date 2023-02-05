namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Open a door or chest
    /// </summary>
    [Serializable]
    internal class OpenCommand : Command
    {
        private OpenCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'o';

        public override int? Repeat => 99;

        public override bool Execute()
        {
            return SaveGame.DoCmdOpen();
        }
    }
}
