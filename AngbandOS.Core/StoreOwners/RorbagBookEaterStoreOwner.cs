[Serializable]
internal class RorbagBookEaterStoreOwner : StoreOwner
{
    private RorbagBookEaterStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Rorbag Book-Eater";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<KoboldRace>();
}