[Serializable]
internal class GandarTheNeutralStoreOwner : StoreOwner
{
    private GandarTheNeutralStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Gandar the Neutral";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}