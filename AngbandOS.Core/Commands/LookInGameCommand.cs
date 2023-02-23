namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Look around (using the target code) stopping on anything interesting rather than just
    /// things that can be targeted
    /// </summary>
    [Serializable]
    internal class LookInGameCommand : InGameCommand
    {
        private LookInGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'l';

        public override bool Execute()
        {
            SaveGame.DoCmdLook();
            return false;
        }
    }
}
