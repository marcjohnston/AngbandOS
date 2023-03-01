[Serializable]
internal class AnastasiaTheLuminousStoreOwner : StoreOwner
{
    private AnastasiaTheLuminousStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Anastasia the Luminous";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SpectreRace>();
}