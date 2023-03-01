[Serializable]
internal class ArndalBeastSlayerStoreOwner : StoreOwner
{
    private ArndalBeastSlayerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Arndal Beast-Slayer";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfElfRace>();
}