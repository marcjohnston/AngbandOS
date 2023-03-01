[Serializable]
internal class FelilGandTheSubtleStoreOwner : StoreOwner
{
    private FelilGandTheSubtleStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Felil-Gand the Subtle";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DarkElfRace>();
}