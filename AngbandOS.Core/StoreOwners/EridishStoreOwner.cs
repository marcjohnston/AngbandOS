[Serializable]
internal class EridishStoreOwner : StoreOwner
{
    private EridishStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Eridish";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfTrollRace>();
}