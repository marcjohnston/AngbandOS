[Serializable]
internal class PhilanthropusStoreOwner : StoreOwner
{
    private PhilanthropusStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Philanthropus";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  113;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}