[Serializable]
internal class NarlockStoreOwner : StoreOwner
{
    private NarlockStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Narlock";
    public override int MaxCost =>  1000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}