[Serializable]
internal class RuncieTheInsaneStoreOwner : StoreOwner
{
    private RuncieTheInsaneStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Runcie the Insane";
    public override int MaxCost =>  10000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}