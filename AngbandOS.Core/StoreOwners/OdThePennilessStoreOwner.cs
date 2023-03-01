[Serializable]
internal class OdThePennilessStoreOwner : StoreOwner
{
    private OdThePennilessStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Od the Penniless";
    public override int MaxCost =>  2000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ElfRace>();
}