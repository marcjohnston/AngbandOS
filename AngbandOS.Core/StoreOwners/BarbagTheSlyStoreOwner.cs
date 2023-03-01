[Serializable]
internal class BarbagTheSlyStoreOwner : StoreOwner
{
    private BarbagTheSlyStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Barbag the Sly";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  105;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<KoboldRace>();
}