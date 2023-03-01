[Serializable]
internal class TuethicBareBonesStoreOwner : StoreOwner
{
    private TuethicBareBonesStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Tuethic Bare-Bones";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SkeletonRace>();
}