[Serializable]
internal class SaraiTheSwiftStoreOwner : StoreOwner
{
    private SaraiTheSwiftStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Sarai the Swift";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}