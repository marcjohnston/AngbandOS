[Serializable]
internal class FalilmawenTheFriendlyStoreOwner : StoreOwner
{
    private FalilmawenTheFriendlyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Falilmawen the Friendly";
    public override int MaxCost =>  250;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}