[Serializable]
internal class VrudushTheShamanStoreOwner : StoreOwner
{
    private VrudushTheShamanStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Vrudush the Shaman";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOgreRace>();
}