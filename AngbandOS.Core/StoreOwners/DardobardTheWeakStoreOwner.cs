[Serializable]
internal class DardobardTheWeakStoreOwner : StoreOwner
{
    private DardobardTheWeakStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Dardobard the Weak";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  109;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<SpectreRace>();
}