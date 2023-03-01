[Serializable]
internal class WutoPoisonbreathStoreOwner : StoreOwner
{
    private WutoPoisonbreathStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Wuto Poisonbreath";
    public override int MaxCost =>  750;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DraconianRace>();
}