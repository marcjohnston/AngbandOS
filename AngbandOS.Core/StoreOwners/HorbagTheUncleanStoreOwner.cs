[Serializable]
internal class HorbagTheUncleanStoreOwner : StoreOwner
{
    private HorbagTheUncleanStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Horbag the Unclean";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOrcRace>();
}