[Serializable]
internal class OrraxDragonsonStoreOwner : StoreOwner
{
    private OrraxDragonsonStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Orrax Dragonson";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DraconianRace>();
}