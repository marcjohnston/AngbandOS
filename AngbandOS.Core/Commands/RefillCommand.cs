namespace AngbandOS.Commands
{
    /// <summary>
    /// Refill a light source with fuel
    /// </summary>
    [Serializable]
    internal class RefillCommand : Command
    {
        private RefillCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'F';

        public override bool Execute()
        {
            SaveGame.DoCmdRefill();
            return false;
        }
    }
}
