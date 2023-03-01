[Serializable]
internal class ButchStoreOwner : StoreOwner
{
    private ButchStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Butch";
    public override int MaxCost =>  250;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOrcRace>();
}