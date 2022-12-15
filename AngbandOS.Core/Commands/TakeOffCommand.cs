using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Take off an item
    /// </summary>
    [Serializable]
    internal class TakeOffCommand : ICommand
    {
        public char Key => 't';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            TakeOffStoreCommand.DoCmdTakeOff(saveGame);
        }
    }
}
