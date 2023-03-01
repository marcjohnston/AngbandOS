[Serializable]
internal class MuirtTheVirtuousStoreOwner : StoreOwner
{
    private MuirtTheVirtuousStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Muirt the Virtuous";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  107;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<KoboldRace>();
}