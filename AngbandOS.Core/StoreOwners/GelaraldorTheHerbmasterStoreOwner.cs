[Serializable]
internal class GelaraldorTheHerbmasterStoreOwner : StoreOwner
{
    private GelaraldorTheHerbmasterStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Gelaraldor the Herbmaster";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HighElfRace>();
}