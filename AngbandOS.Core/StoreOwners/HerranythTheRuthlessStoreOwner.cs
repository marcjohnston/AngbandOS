[Serializable]
internal class HerranythTheRuthlessStoreOwner : StoreOwner
{
    private HerranythTheRuthlessStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Herranyth the Ruthless";
    public override int MaxCost =>  2000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}