[Serializable]
internal class FilbertTheHungryStoreOwner : StoreOwner
{
    private FilbertTheHungryStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Filbert the Hungry";
    public override int MaxCost =>  750;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}