[Serializable]
internal class KynTheTreacherousStoreOwner : StoreOwner
{
    private KynTheTreacherousStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Kyn the Treacherous";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<VampireRace>();
}