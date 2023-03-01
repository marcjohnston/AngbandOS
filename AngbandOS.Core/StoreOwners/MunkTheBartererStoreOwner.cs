[Serializable]
internal class MunkTheBartererStoreOwner : StoreOwner
{
    private MunkTheBartererStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Munk the Barterer";
    public override int MaxCost =>  2000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOgreRace>();
}