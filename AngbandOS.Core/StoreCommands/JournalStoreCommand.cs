
namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Look in the player's journal for any one of a number of different reasons
    /// </summary>
    [Serializable]
    internal class JournalStoreCommand : BaseStoreCommand
    {
        public override char Key => 'J';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            DoCmdJournal(storeCommandEvent.SaveGame);
            storeCommandEvent.RequiresRerendering = true;
        }

        public static void DoCmdJournal(SaveGame saveGame)
        {
            // Let the journal itself handle it from here
            Journal journal = new Journal(saveGame);
            journal.ShowMenu();
        }
    }
}
