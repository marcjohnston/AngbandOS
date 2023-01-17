namespace AngbandOS.Commands
{
    /// <summary>
    /// Retire (if a winner) or give up (if not a winner)
    /// </summary>
    [Serializable]
    internal class RetireCommand : Command
    {
        private RetireCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'Q';

        public override bool Execute()
        {
            SaveGame.DoCmdRetire();
            return false;
        }
    }
}
