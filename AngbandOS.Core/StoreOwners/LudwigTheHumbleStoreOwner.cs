[Serializable]
internal class LudwigTheHumbleStoreOwner : StoreOwner
{
    private LudwigTheHumbleStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ludwig the Humble";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}