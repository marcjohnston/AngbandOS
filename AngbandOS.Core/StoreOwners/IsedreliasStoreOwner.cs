[Serializable]
internal class IsedreliasStoreOwner : StoreOwner
{
    private IsedreliasStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Isedrelias";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SpriteRace>();
}