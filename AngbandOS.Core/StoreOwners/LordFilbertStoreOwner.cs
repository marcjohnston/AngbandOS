[Serializable]
internal class LordFilbertStoreOwner : StoreOwner
{
    private LordFilbertStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Lord Filbert";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}