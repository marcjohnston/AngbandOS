namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Show the player what a particular symbol represents
    /// </summary>
    [Serializable]
    internal class QuerySymbolGameCommand : GameCommand
    {
        private QuerySymbolGameCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '/';

        public override bool Execute()
        {
            SaveGame.DoCmdQuerySymbol();
            return false;
        }
    }
}
