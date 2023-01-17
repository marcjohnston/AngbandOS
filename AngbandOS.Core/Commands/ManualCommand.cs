namespace AngbandOS.Commands
{
    /// <summary>
    /// Show the game manual
    /// </summary>
    [Serializable]
    internal class ManualCommand : Command
    {
        private ManualCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'h';

        public override bool Execute()
        {
            SaveGame.DoCmdManual();
            return false;
        }
    }
}
