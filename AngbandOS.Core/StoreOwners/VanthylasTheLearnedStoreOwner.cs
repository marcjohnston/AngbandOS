[Serializable]
internal class VanthylasTheLearnedStoreOwner : StoreOwner
{
    private VanthylasTheLearnedStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Vanthylas the Learned";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MindFlayerRace>();
}