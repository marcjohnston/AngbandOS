[Serializable]
internal class FungusGiantSlayerStoreOwner : StoreOwner
{
    private FungusGiantSlayerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Fungus Giant-Slayer";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}