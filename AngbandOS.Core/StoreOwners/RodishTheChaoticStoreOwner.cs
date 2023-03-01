[Serializable]
internal class RodishTheChaoticStoreOwner : StoreOwner
{
    private RodishTheChaoticStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Rodish the Chaotic";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MiriNigriRace>();
}