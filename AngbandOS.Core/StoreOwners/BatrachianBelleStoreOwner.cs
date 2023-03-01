[Serializable]
internal class BatrachianBelleStoreOwner : StoreOwner
{
    private BatrachianBelleStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Batrachian Belle";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  150;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MiriNigriRace>();
}