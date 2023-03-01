[Serializable]
internal class YojoIIStoreOwner : StoreOwner
{
    private YojoIIStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Yojo II";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}