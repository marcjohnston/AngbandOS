[Serializable]
internal class OddoYeeksonStoreOwner : StoreOwner
{
    private OddoYeeksonStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Oddo Yeekson";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<YeekRace>();
}