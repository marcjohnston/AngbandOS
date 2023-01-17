namespace AngbandOS.Commands
{
    /// <summary>
    /// Bash a door to open it
    /// </summary>
    [Serializable]
    internal class BashCommand : Command
    {
        private BashCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'B';

        public override int? Repeat => 99;

        public override bool Execute()
        {
            return SaveGame.DoBash();
        }
    }
}
