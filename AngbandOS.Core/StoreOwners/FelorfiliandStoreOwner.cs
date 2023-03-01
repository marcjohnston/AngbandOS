[Serializable]
internal class FelorfiliandStoreOwner : StoreOwner
{
    private FelorfiliandStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Felorfiliand";
    public override int MaxCost =>  500;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ElfRace>();
}