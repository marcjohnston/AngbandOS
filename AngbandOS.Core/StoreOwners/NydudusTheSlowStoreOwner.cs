[Serializable]
internal class NydudusTheSlowStoreOwner : StoreOwner
{
    private NydudusTheSlowStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Nydudus the Slow";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}