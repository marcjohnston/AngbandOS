[Serializable]
internal class SolostoranStoreOwner : StoreOwner
{
    private SolostoranStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Solostoran";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SpriteRace>();
}