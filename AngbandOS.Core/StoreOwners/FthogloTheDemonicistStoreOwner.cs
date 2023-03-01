[Serializable]
internal class FthogloTheDemonicistStoreOwner : StoreOwner
{
    private FthogloTheDemonicistStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Fthoglo the Demonicist";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  116;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ImpRace>();
}