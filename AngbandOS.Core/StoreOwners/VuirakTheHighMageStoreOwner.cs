[Serializable]
internal class VuirakTheHighMageStoreOwner : StoreOwner
{
    private VuirakTheHighMageStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Vuirak the High-Mage";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MiriNigriRace>();
}