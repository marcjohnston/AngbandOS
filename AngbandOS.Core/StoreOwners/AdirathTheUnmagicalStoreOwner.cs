[Serializable]
internal class AdirathTheUnmagicalStoreOwner : StoreOwner
{
    private AdirathTheUnmagicalStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Adirath the Unmagical";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}