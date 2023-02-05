namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Repeat the level feeling for the player and also say where we are
    /// </summary>
    [Serializable]
    internal class FeelingAndLocationCommand : Command
    {
        private FeelingAndLocationCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'H';

        public override bool Execute()
        {
            SaveGame.DoCmdFeeling(false);
            return false;
        }
    }
}
