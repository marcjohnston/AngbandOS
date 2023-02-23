namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Show the game manual
    /// </summary>
    [Serializable]
    internal class ManualInGameCommand : InGameCommand
    {
        private ManualInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'h';

        public override bool Execute()
        {
            SaveGame.DoCmdManual();
            return false;
        }
    }
}
