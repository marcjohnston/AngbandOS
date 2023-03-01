[Serializable]
internal class PaetlanTheAlcoholicStoreOwner : StoreOwner
{
    private PaetlanTheAlcoholicStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Paetlan the Alcoholic";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}