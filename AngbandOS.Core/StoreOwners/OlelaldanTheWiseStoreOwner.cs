[Serializable]
internal class OlelaldanTheWiseStoreOwner : StoreOwner
{
    private OlelaldanTheWiseStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Olelaldan the Wise";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}