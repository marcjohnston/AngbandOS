namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Attempt to disarm a trap on a door or chest
    /// </summary>
    [Serializable]
    internal class DisarmInGameCommand : InGameCommand
    {
        private DisarmInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'D';

        public override int? Repeat => 99;

        public override bool Execute()
        {
            return SaveGame.DoDisarm();
        }
    }
}
