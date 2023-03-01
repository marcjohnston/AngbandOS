[Serializable]
internal class YourHomeStoreOwner : StoreOwner
{
    private YourHomeStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Your home";
    public override int MaxCost =>  0;
    public override int MinInflate =>  100;
    public override Race? OwnerRace =>  null;
}