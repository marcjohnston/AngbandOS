[Serializable]
internal class BuggerbyTheGreatStoreOwner : StoreOwner
{
    private BuggerbyTheGreatStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Buggerby the Great";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  113;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GnomeRace>();
}