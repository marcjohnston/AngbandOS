[Serializable]
internal class VengellaTheCruelStoreOwner : StoreOwner
{
    private VengellaTheCruelStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Vengella the Cruel";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfTrollRace>();
}