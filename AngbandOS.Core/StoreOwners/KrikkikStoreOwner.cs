[Serializable]
internal class KrikkikStoreOwner : StoreOwner
{
    private KrikkikStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Krikkik";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<KlackonRace>();
}