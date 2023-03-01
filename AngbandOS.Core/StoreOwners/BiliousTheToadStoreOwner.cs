[Serializable]
internal class BiliousTheToadStoreOwner : StoreOwner
{
    private BiliousTheToadStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Bilious the Toad";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MiriNigriRace>();
}