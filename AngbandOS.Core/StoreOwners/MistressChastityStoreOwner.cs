[Serializable]
internal class MistressChastityStoreOwner : StoreOwner
{
    private MistressChastityStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Mistress Chastity";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HighElfRace>();
}