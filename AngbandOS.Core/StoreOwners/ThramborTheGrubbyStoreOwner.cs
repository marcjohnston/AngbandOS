[Serializable]
internal class ThramborTheGrubbyStoreOwner : StoreOwner
{
    private ThramborTheGrubbyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Thrambor the Grubby";
    public override int MaxCost =>  5000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfElfRace>();
}