[Serializable]
internal class XochinagguaStoreOwner : StoreOwner
{
    private XochinagguaStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Xochinaggua";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MindFlayerRace>();
}