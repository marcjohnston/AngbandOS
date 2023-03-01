[Serializable]
internal class ThalegordTheShamanStoreOwner : StoreOwner
{
    private ThalegordTheShamanStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Thalegord the Shaman";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}