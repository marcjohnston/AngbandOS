[Serializable]
internal class AldousTheSleepyStoreOwner : StoreOwner
{
    private AldousTheSleepyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Aldous the Sleepy";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}