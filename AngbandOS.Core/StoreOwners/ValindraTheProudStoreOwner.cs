[Serializable]
internal class ValindraTheProudStoreOwner : StoreOwner
{
    private ValindraTheProudStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Valindra the Proud";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  116;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HighElfRace>();
}