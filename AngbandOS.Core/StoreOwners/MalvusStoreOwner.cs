[Serializable]
internal class MalvusStoreOwner : StoreOwner
{
    private MalvusStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Malvus";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfTitanRace>();
}