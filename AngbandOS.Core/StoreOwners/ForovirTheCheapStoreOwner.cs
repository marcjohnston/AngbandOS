[Serializable]
internal class ForovirTheCheapStoreOwner : StoreOwner
{
    private ForovirTheCheapStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Forovir the Cheap";
    public override int MaxCost =>  250;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}