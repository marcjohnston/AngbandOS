[Serializable]
internal class CinaTheRogueStoreOwner : StoreOwner
{
    private CinaTheRogueStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Cina the Rogue";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GnomeRace>();
}