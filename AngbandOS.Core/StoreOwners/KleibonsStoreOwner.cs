[Serializable]
internal class KleibonsStoreOwner : StoreOwner
{
    private KleibonsStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Kleibons";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<KlackonRace>();
}