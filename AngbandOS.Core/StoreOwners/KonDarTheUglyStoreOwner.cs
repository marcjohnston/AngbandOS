[Serializable]
internal class KonDarTheUglyStoreOwner : StoreOwner
{
    private KonDarTheUglyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Kon-Dar the Ugly";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOrcRace>();
}