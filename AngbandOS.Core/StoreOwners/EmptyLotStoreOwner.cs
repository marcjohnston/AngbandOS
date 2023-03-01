[Serializable]
internal class EmptyLotStoreOwner : StoreOwner
{
    private EmptyLotStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Empty lot";
    public override int MaxCost =>  0;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  null;
}