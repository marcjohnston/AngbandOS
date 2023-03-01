[Serializable]
internal class GranthusStoreOwner : StoreOwner
{
    private GranthusStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Granthus";
    public override int MaxCost =>  750;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SkeletonRace>();
}