using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Examine an item
    /// </summary>
    [Serializable]
    internal class ExamineCommand : ICommand
    {
        private ExamineCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'x';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            ExamineInventoryStoreCommand.DoCmdExamine(saveGame);
        }
    }
}
