[Serializable]
internal class YaarjukkaDemonspawnStoreOwner : StoreOwner
{
    private YaarjukkaDemonspawnStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Yaarjukka Demonspawn";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ImpRace>();
}