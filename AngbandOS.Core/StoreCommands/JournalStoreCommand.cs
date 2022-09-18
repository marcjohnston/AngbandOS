using AngbandOS.Commands;
using System;

namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Look in the player's journal for any one of a number of different reasons
    /// </summary>
    [Serializable]
    internal class JournalStoreCommand : IStoreCommand
    {
        public char Key => 'J';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => true;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdJournal(saveGame);
        }

        public static void DoCmdJournal(SaveGame saveGame)
        {
            // Let the journal itself handle it from here
            Journal journal = new Journal(saveGame);
            journal.ShowMenu();
        }
    }
}
