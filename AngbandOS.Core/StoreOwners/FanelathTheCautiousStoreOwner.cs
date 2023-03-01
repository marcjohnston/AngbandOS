[Serializable]
internal class FanelathTheCautiousStoreOwner : StoreOwner
{
    private FanelathTheCautiousStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Fanelath the Cautious";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}