[Serializable]
internal class PoogorTheDumbStoreOwner : StoreOwner
{
    private PoogorTheDumbStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Poogor the Dumb";
    public override int MaxCost =>  250;
    public override int MinInflate =>  108;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<MiriNigriRace>();
}