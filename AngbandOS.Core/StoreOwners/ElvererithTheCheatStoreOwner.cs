[Serializable]
internal class ElvererithTheCheatStoreOwner : StoreOwner
{
    private ElvererithTheCheatStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Elvererith the Cheat";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DarkElfRace>();
}