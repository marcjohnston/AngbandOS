[Serializable]
internal class MagdTheRuthlessStoreOwner : StoreOwner
{
    private MagdTheRuthlessStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Magd the Ruthless";
    public override int MaxCost =>  2000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}