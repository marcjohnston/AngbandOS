[Serializable]
internal class BalennWarDancerStoreOwner : StoreOwner
{
    private BalennWarDancerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Balenn War-Dancer";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}