[Serializable]
internal class NafurTheWoodenStoreOwner : StoreOwner
{
    private NafurTheWoodenStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Nafur the Wooden";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GolemRace>();
}