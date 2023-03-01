[Serializable]
internal class MerullaTheHumbleStoreOwner : StoreOwner
{
    private MerullaTheHumbleStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Merulla the Humble";
    public override int MaxCost =>  1000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ElfRace>();
}