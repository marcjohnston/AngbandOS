[Serializable]
internal class VamogSlayerStoreOwner : StoreOwner
{
    private VamogSlayerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Vamog Slayer";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOgreRace>();
}