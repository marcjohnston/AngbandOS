[Serializable]
internal class DrakoFairdealStoreOwner : StoreOwner
{
    private DrakoFairdealStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Drako Fairdeal";
    public override int MaxCost =>  4000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DraconianRace>();
}