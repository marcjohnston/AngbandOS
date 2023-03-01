[Serializable]
internal class QuickArmVollaireStoreOwner : StoreOwner
{
    private QuickArmVollaireStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Quick-Arm Vollaire";
    public override int MaxCost =>  4000;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}