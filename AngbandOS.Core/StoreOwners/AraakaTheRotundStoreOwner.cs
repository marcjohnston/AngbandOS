[Serializable]
internal class AraakaTheRotundStoreOwner : StoreOwner
{
    private AraakaTheRotundStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Araaka the Rotund";
    public override int MaxCost =>  1000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DraconianRace>();
}