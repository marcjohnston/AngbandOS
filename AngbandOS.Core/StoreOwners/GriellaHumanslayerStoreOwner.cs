[Serializable]
internal class GriellaHumanslayerStoreOwner : StoreOwner
{
    private GriellaHumanslayerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Griella Humanslayer";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ImpRace>();
}