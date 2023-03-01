[Serializable]
internal class LathaxlTheGreedyStoreOwner : StoreOwner
{
    private LathaxlTheGreedyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Lathaxl the Greedy";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MindFlayerRace>();
}