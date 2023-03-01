[Serializable]
internal class ArunikkiGreatclawStoreOwner : StoreOwner
{
    private ArunikkiGreatclawStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Arunikki Greatclaw";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DraconianRace>();
}