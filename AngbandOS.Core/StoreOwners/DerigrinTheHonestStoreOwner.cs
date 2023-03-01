[Serializable]
internal class DerigrinTheHonestStoreOwner : StoreOwner
{
    private DerigrinTheHonestStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Derigrin the Honest";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}