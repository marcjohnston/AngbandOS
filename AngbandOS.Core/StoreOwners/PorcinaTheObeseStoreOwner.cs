[Serializable]
internal class PorcinaTheObeseStoreOwner : StoreOwner
{
    private PorcinaTheObeseStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Porcina the Obese";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfOrcRace>();
}