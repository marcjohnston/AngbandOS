[Serializable]
internal class PeadusTheCruelStoreOwner : StoreOwner
{
    private PeadusTheCruelStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Peadus the Cruel";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}