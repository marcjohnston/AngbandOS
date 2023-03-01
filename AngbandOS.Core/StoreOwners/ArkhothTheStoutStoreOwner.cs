[Serializable]
internal class ArkhothTheStoutStoreOwner : StoreOwner
{
    private ArkhothTheStoutStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Arkhoth the Stout";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}