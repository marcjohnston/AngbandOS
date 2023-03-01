[Serializable]
internal class HashnikTheDruidStoreOwner : StoreOwner
{
    private HashnikTheDruidStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Hashnik the Druid";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}