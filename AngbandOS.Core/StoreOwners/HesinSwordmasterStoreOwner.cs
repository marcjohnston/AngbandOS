[Serializable]
internal class HesinSwordmasterStoreOwner : StoreOwner
{
    private HesinSwordmasterStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Hesin Swordmaster";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<NibelungRace>();
}