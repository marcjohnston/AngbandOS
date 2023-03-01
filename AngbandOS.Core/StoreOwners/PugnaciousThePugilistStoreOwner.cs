[Serializable]
internal class PugnaciousThePugilistStoreOwner : StoreOwner
{
    private PugnaciousThePugilistStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Pugnacious the Pugilist";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOrcRace>();
}