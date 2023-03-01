[Serializable]
internal class EdorTheShortStoreOwner : StoreOwner
{
    private EdorTheShortStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Edor the Short";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HobbitRace>();
}