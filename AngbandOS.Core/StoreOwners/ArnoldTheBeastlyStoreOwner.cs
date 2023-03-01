[Serializable]
internal class ArnoldTheBeastlyStoreOwner : StoreOwner
{
    private ArnoldTheBeastlyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Arnold the Beastly";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}