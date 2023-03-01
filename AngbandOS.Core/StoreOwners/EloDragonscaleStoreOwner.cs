[Serializable]
internal class EloDragonscaleStoreOwner : StoreOwner
{
    private EloDragonscaleStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Elo Dragonscale";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ElfRace>();
}