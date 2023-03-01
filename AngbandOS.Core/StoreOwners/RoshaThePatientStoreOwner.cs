[Serializable]
internal class RoshaThePatientStoreOwner : StoreOwner
{
    private RoshaThePatientStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Ro-sha the Patient";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GolemRace>();
}