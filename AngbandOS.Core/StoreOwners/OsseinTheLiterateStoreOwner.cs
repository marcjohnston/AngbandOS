[Serializable]
internal class OsseinTheLiterateStoreOwner : StoreOwner
{
    private OsseinTheLiterateStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ossein the Literate";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SkeletonRace>();
}