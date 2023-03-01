[Serializable]
internal class AsuunuTheLearnedStoreOwner : StoreOwner
{
    private AsuunuTheLearnedStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Asuunu the Learned";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MindFlayerRace>();
}