[Serializable]
internal class PrenticeTheTrustedStoreOwner : StoreOwner
{
    private PrenticeTheTrustedStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Prentice the Trusted";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SkeletonRace>();
}