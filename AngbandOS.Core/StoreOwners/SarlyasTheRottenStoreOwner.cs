[Serializable]
internal class SarlyasTheRottenStoreOwner : StoreOwner
{
    private SarlyasTheRottenStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Sarlyas the Rotten";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ZombieRace>();
}