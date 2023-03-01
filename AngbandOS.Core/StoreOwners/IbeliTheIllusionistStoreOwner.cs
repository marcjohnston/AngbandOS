[Serializable]
internal class IbeliTheIllusionistStoreOwner : StoreOwner
{
    private IbeliTheIllusionistStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ibeli the Illusionist";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SkeletonRace>();
}