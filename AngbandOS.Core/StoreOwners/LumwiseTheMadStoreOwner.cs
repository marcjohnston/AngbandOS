[Serializable]
internal class LumwiseTheMadStoreOwner : StoreOwner
{
    private LumwiseTheMadStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Lumwise the Mad";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<YeekRace>();
}