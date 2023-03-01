[Serializable]
internal class DryBonesStoreOwner : StoreOwner
{
    private DryBonesStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Dry-Bones";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SkeletonRace>();
}