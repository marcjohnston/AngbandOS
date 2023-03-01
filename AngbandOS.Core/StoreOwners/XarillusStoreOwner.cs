[Serializable]
internal class XarillusStoreOwner : StoreOwner
{
    private XarillusStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Xarillus";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}