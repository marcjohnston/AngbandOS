[Serializable]
internal class GunnarThePaladinStoreOwner : StoreOwner
{
    private GunnarThePaladinStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Gunnar the Paladin";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfTrollRace>();
}