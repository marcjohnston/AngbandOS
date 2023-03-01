[Serializable]
internal class KeldornTheGrandStoreOwner : StoreOwner
{
    private KeldornTheGrandStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Keldorn the Grand";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}