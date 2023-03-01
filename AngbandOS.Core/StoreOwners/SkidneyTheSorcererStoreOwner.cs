[Serializable]
internal class SkidneyTheSorcererStoreOwner : StoreOwner
{
    private SkidneyTheSorcererStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Skidney the Sorcerer";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HalfElfRace>();
}