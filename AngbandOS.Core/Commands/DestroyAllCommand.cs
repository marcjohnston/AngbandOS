namespace AngbandOS.Commands
{
    /// <summary>
    /// Destroy all worthless items in your pack
    /// </summary>
    [Serializable]
    internal class DestroyAllCommand : ICommand
    {
        private DestroyAllCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'K';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DestroyAllStoreCommand.DoCmdDestroyAll(saveGame);
        }
    }
}
