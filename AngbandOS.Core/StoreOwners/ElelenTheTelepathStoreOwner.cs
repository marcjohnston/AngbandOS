[Serializable]
internal class ElelenTheTelepathStoreOwner : StoreOwner
{
    private ElelenTheTelepathStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Elelen the Telepath";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DarkElfRace>();
}