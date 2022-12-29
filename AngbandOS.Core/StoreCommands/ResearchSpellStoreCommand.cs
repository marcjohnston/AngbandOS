namespace AngbandOS.StoreCommands
{
    internal class ResearchSpellStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "Research a spell";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.ResearchSpell();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreLibrary);
    }
}
