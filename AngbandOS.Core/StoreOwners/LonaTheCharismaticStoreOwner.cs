[Serializable]
internal class LonaTheCharismaticStoreOwner : StoreOwner
{
    private LonaTheCharismaticStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Lona the Charismatic";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GnomeRace>();
}