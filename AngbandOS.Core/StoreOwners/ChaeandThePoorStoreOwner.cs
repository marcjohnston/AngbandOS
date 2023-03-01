[Serializable]
internal class ChaeandThePoorStoreOwner : StoreOwner
{
    private ChaeandThePoorStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Chaeand the Poor";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}