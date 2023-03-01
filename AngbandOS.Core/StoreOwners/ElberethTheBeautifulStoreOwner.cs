[Serializable]
internal class ElberethTheBeautifulStoreOwner : StoreOwner
{
    private ElberethTheBeautifulStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Elbereth the Beautiful";
    public override int MaxCost =>  500;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HighElfRace>();
}