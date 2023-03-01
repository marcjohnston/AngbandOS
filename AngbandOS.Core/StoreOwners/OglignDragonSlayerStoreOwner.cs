[Serializable]
internal class OglignDragonSlayerStoreOwner : StoreOwner
{
    private OglignDragonSlayerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Oglign Dragon-Slayer";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}