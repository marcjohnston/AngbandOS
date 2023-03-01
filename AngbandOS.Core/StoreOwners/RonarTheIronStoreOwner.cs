[Serializable]
internal class RonarTheIronStoreOwner : StoreOwner
{
    private RonarTheIronStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ronar the Iron";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GolemRace>();
}