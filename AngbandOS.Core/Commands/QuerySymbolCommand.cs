namespace AngbandOS.Commands
{
    /// <summary>
    /// Show the player what a particular symbol represents
    /// </summary>
    [Serializable]
    internal class QuerySymbolCommand : Command
    {
        private QuerySymbolCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '/';

        public override bool Execute()
        {
            SaveGame.DoCmdQuerySymbol();
            return false;
        }
    }
}
