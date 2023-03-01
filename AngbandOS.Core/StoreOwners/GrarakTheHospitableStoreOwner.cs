[Serializable]
internal class GrarakTheHospitableStoreOwner : StoreOwner
{
    private GrarakTheHospitableStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Grarak the Hospitable";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfGiantRace>();
}