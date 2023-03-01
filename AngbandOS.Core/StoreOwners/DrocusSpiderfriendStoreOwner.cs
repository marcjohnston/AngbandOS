[Serializable]
internal class DrocusSpiderfriendStoreOwner : StoreOwner
{
    private DrocusSpiderfriendStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Drocus Spiderfriend";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DarkElfRace>();
}