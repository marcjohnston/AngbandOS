[Serializable]
internal class EllefrisThePaladinStoreOwner : StoreOwner
{
    private EllefrisThePaladinStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ellefris the Paladin";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}