[Serializable]
internal class GrugTheComelyStoreOwner : StoreOwner
{
    private GrugTheComelyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Grug the Comely";
    public override int MaxCost =>  1000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfTitanRace>();
}