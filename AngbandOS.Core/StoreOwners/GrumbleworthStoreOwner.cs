[Serializable]
internal class GrumbleworthStoreOwner : StoreOwner
{
    private GrumbleworthStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Grumbleworth";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  116;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GnomeRace>();
}