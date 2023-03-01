[Serializable]
internal class SirParsivalThePureStoreOwner : StoreOwner
{
    private SirParsivalThePureStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Sir Parsival the Pure";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HighElfRace>();
}