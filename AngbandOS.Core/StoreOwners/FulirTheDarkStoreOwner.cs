[Serializable]
internal class FulirTheDarkStoreOwner : StoreOwner
{
    private FulirTheDarkStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Fulir the Dark";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<NibelungRace>();
}