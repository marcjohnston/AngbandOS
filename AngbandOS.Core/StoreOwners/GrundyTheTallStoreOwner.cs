[Serializable]
internal class GrundyTheTallStoreOwner : StoreOwner
{
    private GrundyTheTallStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Grundy the Tall";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}