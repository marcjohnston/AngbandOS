[Serializable]
internal class EtheraaTheFuriousStoreOwner : StoreOwner
{
    private EtheraaTheFuriousStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Etheraa the Furious";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<TchoTchoRace>();
}