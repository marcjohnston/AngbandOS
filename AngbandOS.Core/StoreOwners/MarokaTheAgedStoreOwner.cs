[Serializable]
internal class MarokaTheAgedStoreOwner : StoreOwner
{
    private MarokaTheAgedStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Maroka the Aged";
    public override int MaxCost =>  750;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GnomeRace>();
}