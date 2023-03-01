[Serializable]
internal class HurkThePoorStoreOwner : StoreOwner
{
    private HurkThePoorStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Hurk the Poor";
    public override int MaxCost =>  500;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOrcRace>();
}