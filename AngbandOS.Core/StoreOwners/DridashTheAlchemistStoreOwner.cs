[Serializable]
internal class DridashTheAlchemistStoreOwner : StoreOwner
{
    private DridashTheAlchemistStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Dridash the Alchemist";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOrcRace>();
}