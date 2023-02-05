namespace AngbandOS.Core.StoreCommands
{
    [Serializable]
    internal class ResearchSpellStoreCommand : BaseStoreCommand

    {
        private ResearchSpellStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "Research a spell";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreLibrary);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.ResearchSpell();
        }
    }
}
