[Serializable]
internal class SarlethTheSneakyStoreOwner : StoreOwner
{
    private SarlethTheSneakyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Sarleth the Sneaky";
    public override int MaxCost =>  750;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GnomeRace>();
}