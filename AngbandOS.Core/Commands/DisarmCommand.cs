namespace AngbandOS.Commands
{
    /// <summary>
    /// Attempt to disarm a trap on a door or chest
    /// </summary>
    [Serializable]
    internal class DisarmCommand : Command
    {
        private DisarmCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'D';

        public override int? Repeat => 99;

        public override bool Execute()
        {
            return SaveGame.DoDisarm();
        }
    }
}
