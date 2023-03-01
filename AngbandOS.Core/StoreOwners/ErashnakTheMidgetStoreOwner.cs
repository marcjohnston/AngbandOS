[Serializable]
internal class ErashnakTheMidgetStoreOwner : StoreOwner
{
    private ErashnakTheMidgetStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Erashnak the Midget";
    public override int MaxCost =>  750;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MiriNigriRace>();
}