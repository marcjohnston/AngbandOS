[Serializable]
internal class IbeniddTheChasteStoreOwner : StoreOwner
{
    private IbeniddTheChasteStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ibenidd the Chaste";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}