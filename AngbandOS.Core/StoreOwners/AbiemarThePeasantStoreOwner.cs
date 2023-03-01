[Serializable]
internal class AbiemarThePeasantStoreOwner : StoreOwner
{
    private AbiemarThePeasantStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Abiemar the Peasant";
    public override int MaxCost =>  250;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}