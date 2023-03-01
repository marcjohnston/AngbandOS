[Serializable]
internal class GruceTheHugeStoreOwner : StoreOwner
{
    private GruceTheHugeStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Gruce the Huge";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfGiantRace>();
}