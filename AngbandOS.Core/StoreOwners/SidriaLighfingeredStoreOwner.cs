[Serializable]
internal class SidriaLighfingeredStoreOwner : StoreOwner
{
    private SidriaLighfingeredStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Sidria Lighfingered";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}