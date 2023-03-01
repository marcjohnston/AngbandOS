[Serializable]
internal class FurfaceYeekStoreOwner : StoreOwner
{
    private FurfaceYeekStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Furface Yeek";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<YeekRace>();
}