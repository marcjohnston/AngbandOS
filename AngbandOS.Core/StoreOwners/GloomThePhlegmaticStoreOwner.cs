[Serializable]
internal class GloomThePhlegmaticStoreOwner : StoreOwner
{
    private GloomThePhlegmaticStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Gloom the Phlegmatic";
    public override int MaxCost =>  2000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}