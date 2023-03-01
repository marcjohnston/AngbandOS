[Serializable]
internal class DargLowTheGrimStoreOwner : StoreOwner
{
    private DargLowTheGrimStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Darg-Low the Grim";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}