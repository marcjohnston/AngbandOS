[Serializable]
internal class AtalTheWiseStoreOwner : StoreOwner
{
    private AtalTheWiseStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Atal the Wise";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}