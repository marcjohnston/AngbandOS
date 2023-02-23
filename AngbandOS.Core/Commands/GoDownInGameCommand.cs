namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Use a down staircase or trapdoor
    /// </summary>
    [Serializable]
    internal class GoDownInGameCommand : InGameCommand
    {
        private GoDownInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '>';

        public override bool Execute()
        {
            SaveGame.DoGoDown();
            return false;
        }
    }
}
