[Serializable]
internal class KazaTheNobleStoreOwner : StoreOwner
{
    private KazaTheNobleStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Kaza the Noble";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HighElfRace>();
}