[Serializable]
internal class CaydTheSweetStoreOwner : StoreOwner
{
    private CaydTheSweetStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Cayd the Sweet";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}