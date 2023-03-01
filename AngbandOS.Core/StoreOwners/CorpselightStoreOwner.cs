[Serializable]
internal class CorpselightStoreOwner : StoreOwner
{
    private CorpselightStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Corpselight";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SpectreRace>();
}