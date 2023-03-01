[Serializable]
internal class JanaakaTheShiftyStoreOwner : StoreOwner
{
    private JanaakaTheShiftyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Janaaka the Shifty";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GnomeRace>();
}