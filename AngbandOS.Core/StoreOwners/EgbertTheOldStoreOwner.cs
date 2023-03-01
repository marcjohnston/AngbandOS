[Serializable]
internal class EgbertTheOldStoreOwner : StoreOwner
{
    private EgbertTheOldStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Egbert the Old";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}