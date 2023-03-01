[Serializable]
internal class FundiTheSlowStoreOwner : StoreOwner
{
    private FundiTheSlowStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Fundi the Slow";
    public override int MaxCost =>  500;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}