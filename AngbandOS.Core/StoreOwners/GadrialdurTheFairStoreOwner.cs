[Serializable]
internal class GadrialdurTheFairStoreOwner : StoreOwner
{
    private GadrialdurTheFairStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Gadrialdur the Fair";
    public override int MaxCost =>  4000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfElfRace>();
}