[Serializable]
internal class FinakStoreOwner : StoreOwner
{
    private FinakStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Finak";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<YeekRace>();
}