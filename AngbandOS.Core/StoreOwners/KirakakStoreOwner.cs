[Serializable]
internal class KirakakStoreOwner : StoreOwner
{
    private KirakakStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Kirakak";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<KlackonRace>();
}