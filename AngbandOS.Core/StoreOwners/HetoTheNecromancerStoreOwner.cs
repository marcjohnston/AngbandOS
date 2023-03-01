[Serializable]
internal class HetoTheNecromancerStoreOwner : StoreOwner
{
    private HetoTheNecromancerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Heto the Necromancer";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<YeekRace>();
}