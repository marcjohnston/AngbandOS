[Serializable]
internal class QuirmbyTheStrangeStoreOwner : StoreOwner
{
    private QuirmbyTheStrangeStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Quirmby the Strange";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}