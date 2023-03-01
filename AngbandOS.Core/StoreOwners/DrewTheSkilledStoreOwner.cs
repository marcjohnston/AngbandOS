[Serializable]
internal class DrewTheSkilledStoreOwner : StoreOwner
{
    private DrewTheSkilledStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Drew the Skilled";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  115;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}