[Serializable]
internal class RiathoTheJugglerStoreOwner : StoreOwner
{
    private RiathoTheJugglerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Riatho the Juggler";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}