[Serializable]
internal class HelgaTheLostStoreOwner : StoreOwner
{
    private HelgaTheLostStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Helga the Lost";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}