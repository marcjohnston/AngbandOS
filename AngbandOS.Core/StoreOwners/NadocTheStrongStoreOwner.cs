[Serializable]
internal class NadocTheStrongStoreOwner : StoreOwner
{
    private NadocTheStrongStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Nadoc the Strong";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}