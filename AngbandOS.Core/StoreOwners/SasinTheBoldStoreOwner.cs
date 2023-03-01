[Serializable]
internal class SasinTheBoldStoreOwner : StoreOwner
{
    private SasinTheBoldStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Sasin the Bold";
    public override int MaxCost =>  1000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfGiantRace>();
}