[Serializable]
internal class GobblegutsThunderbreathStoreOwner : StoreOwner
{
    private GobblegutsThunderbreathStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Gobbleguts Thunderbreath";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfTrollRace>();
}