[Serializable]
internal class ProogdishTheYouthfullStoreOwner : StoreOwner
{
    private ProogdishTheYouthfullStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Proogdish the Youthfull";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOgreRace>();
}