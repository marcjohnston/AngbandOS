[Serializable]
internal class SevirasTheMindcrafterStoreOwner : StoreOwner
{
    private SevirasTheMindcrafterStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Seviras the Mindcrafter";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}