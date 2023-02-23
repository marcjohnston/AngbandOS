namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Start running
    /// </summary>
    [Serializable]
    internal class RunInGameCommand : InGameCommand
    {
        private RunInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '.';

        public override bool Execute()
        {
            SaveGame.DoCmdRun();
            return true;
        }
    }
}
