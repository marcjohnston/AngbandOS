[Serializable]
internal class ZzathathTheImpStoreOwner : StoreOwner
{
    private ZzathathTheImpStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Zzathath the Imp";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ImpRace>();
}