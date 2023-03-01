[Serializable]
internal class EloiseLongDeadStoreOwner : StoreOwner
{
    private EloiseLongDeadStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Eloise Long-Dead";
    public override int MaxCost =>  250;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SpectreRace>();
}