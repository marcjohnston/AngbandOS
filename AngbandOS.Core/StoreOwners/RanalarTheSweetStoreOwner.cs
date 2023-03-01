[Serializable]
internal class RanalarTheSweetStoreOwner : StoreOwner
{
    private RanalarTheSweetStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ranalar the Sweet";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GreatOneRace>();
}