[Serializable]
internal class LoraxTheSuaveStoreOwner : StoreOwner
{
    private LoraxTheSuaveStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Lorax the Suave";
    public override int MaxCost =>  1000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}