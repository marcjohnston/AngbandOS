[Serializable]
internal class VegnarOneEyeStoreOwner : StoreOwner
{
    private VegnarOneEyeStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Vegnar One-eye";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<CyclopsRace>();
}