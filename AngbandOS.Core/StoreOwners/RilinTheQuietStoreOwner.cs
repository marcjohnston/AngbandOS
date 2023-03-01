[Serializable]
internal class RilinTheQuietStoreOwner : StoreOwner
{
    private RilinTheQuietStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Rilin the Quiet";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}