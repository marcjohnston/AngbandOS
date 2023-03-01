[Serializable]
internal class VhassaTheDeadStoreOwner : StoreOwner
{
    private VhassaTheDeadStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Vhassa the Dead";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}