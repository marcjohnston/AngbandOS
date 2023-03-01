[Serializable]
internal class CharityTheNecromancerStoreOwner : StoreOwner
{
    private CharityTheNecromancerStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Charity the Necromancer";
    public override int MaxCost =>  20000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DarkElfRace>();
}