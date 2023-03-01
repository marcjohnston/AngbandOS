[Serializable]
internal class DecadoTheHandsomeStoreOwner : StoreOwner
{
    private DecadoTheHandsomeStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Decado the Handsome";
    public override int MaxCost =>  25000;
    public override int MinInflate =>  112;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<GreatOneRace>();
}