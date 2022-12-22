using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Destroy a single item
    /// </summary>
    [Serializable]
    internal class DestroyCommand : ICommand
    {
        private DestroyCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'k';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DestroyStoreCommand.DoCmdDestroy(saveGame);
        }
    }
}
