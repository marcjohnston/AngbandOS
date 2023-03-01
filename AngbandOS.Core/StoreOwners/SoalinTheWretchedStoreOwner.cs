[Serializable]
internal class SoalinTheWretchedStoreOwner : StoreOwner
{
    private SoalinTheWretchedStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Soalin the Wretched";
    public override int MaxCost =>  750;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}