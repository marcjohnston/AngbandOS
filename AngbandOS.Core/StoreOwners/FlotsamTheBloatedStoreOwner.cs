[Serializable]
internal class FlotsamTheBloatedStoreOwner : StoreOwner
{
    private FlotsamTheBloatedStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Flotsam the Bloated";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}