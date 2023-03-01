[Serializable]
internal class LoirinTheMadStoreOwner : StoreOwner
{
    private LoirinTheMadStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Loirin the Mad";
    public override int MaxCost =>  500;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfGiantRace>();
}