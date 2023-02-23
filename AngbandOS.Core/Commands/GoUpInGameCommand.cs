namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Go up a staircase
    /// </summary>
    [Serializable]
    internal class GoUpInGameCommand : InGameCommand
    {
        private GoUpInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '<';

        public override bool Execute()
        {
            SaveGame.DoGoUp();
            return false;
        }
    }
}
