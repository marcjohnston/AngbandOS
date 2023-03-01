[Serializable]
internal class NinarTheStoopedStoreOwner : StoreOwner
{
    private NinarTheStoopedStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ninar the Stooped";
    public override int MaxCost =>  5000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}