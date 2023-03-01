[Serializable]
internal class HoshakTheDarkStoreOwner : StoreOwner
{
    private HoshakTheDarkStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Hoshak the Dark";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ImpRace>();
}