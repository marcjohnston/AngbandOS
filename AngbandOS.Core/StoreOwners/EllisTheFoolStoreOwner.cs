[Serializable]
internal class EllisTheFoolStoreOwner : StoreOwner
{
    private EllisTheFoolStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ellis the Fool";
    public override int MaxCost =>  500;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}