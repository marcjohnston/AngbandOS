[Serializable]
internal class DriosTheFaintStoreOwner : StoreOwner
{
    private DriosTheFaintStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Drios the Faint";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SpectreRace>();
}