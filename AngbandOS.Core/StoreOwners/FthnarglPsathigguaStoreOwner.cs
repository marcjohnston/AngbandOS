[Serializable]
internal class FthnarglPsathigguaStoreOwner : StoreOwner
{
    private FthnarglPsathigguaStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Fthnargl Psathiggua";
    public override int MaxCost =>  1000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MindFlayerRace>();
}