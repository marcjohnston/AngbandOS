[Serializable]
internal class AngelStoreOwner : StoreOwner
{
    private AngelStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Angel";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}