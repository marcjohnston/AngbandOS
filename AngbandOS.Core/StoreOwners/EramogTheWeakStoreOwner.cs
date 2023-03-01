[Serializable]
internal class EramogTheWeakStoreOwner : StoreOwner
{
    private EramogTheWeakStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Eramog the Weak";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<KoboldRace>();
}