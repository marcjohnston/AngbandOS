[Serializable]
internal class PrirandTheDeadStoreOwner : StoreOwner
{
    private PrirandTheDeadStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Prirand the Dead";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}