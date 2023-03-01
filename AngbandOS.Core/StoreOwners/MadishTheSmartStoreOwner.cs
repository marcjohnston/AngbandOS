[Serializable]
internal class MadishTheSmartStoreOwner : StoreOwner
{
    private MadishTheSmartStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Madish the Smart";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  113;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MiriNigriRace>();
}