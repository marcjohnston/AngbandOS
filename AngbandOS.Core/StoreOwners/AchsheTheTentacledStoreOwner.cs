[Serializable]
internal class AchsheTheTentacledStoreOwner : StoreOwner
{
    private AchsheTheTentacledStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Achshe the Tentacled";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  113;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MindFlayerRace>();
}