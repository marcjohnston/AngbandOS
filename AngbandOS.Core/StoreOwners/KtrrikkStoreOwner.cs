[Serializable]
internal class KtrrikkStoreOwner : StoreOwner
{
    private KtrrikkStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "K'trrik'k";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<KlackonRace>();
}