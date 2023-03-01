[Serializable]
internal class KyriaTheIllusionistStoreOwner : StoreOwner
{
    private KyriaTheIllusionistStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Kyria the Illusionist";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}