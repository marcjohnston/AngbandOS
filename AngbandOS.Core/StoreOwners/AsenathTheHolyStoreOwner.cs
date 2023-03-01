[Serializable]
internal class AsenathTheHolyStoreOwner : StoreOwner
{
    private AsenathTheHolyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Asenath the Holy";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}