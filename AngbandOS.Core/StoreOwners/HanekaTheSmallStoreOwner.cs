[Serializable]
internal class HanekaTheSmallStoreOwner : StoreOwner
{
    private HanekaTheSmallStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Haneka the Small";
    public override int MaxCost =>  250;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GnomeRace>();
}