[Serializable]
internal class HallOfRecordsStoreOwner : StoreOwner
{
    private HallOfRecordsStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Hall of Records";
    public override int MaxCost =>  0;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  null;
}