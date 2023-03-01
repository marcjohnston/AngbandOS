[Serializable]
internal class XaxStoreOwner : StoreOwner
{
    private XaxStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Xax";
    public override int MaxCost =>  4000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GolemRace>();
}