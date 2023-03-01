[Serializable]
internal class JakeSmallStoreOwner : StoreOwner
{
    private JakeSmallStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Jake Small";
    public override int MaxCost =>  5000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfGiantRace>();
}