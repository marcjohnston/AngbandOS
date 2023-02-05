namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Enter a store
    /// </summary>
    [Serializable]
    internal class StoreCommand : Command
    {
        private StoreCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => '_';

        public override bool Execute()
        {
            SaveGame.DoCmdStore();
            return false;
        }
    }
}
