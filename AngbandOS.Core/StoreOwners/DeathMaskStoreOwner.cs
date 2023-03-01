[Serializable]
internal class DeathMaskStoreOwner : StoreOwner
{
    private DeathMaskStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Death Mask";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}