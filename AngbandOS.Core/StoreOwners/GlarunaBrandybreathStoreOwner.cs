[Serializable]
internal class GlarunaBrandybreathStoreOwner : StoreOwner
{
    private GlarunaBrandybreathStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Glaruna Brandybreath";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}