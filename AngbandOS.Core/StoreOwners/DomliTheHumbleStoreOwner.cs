[Serializable]
internal class DomliTheHumbleStoreOwner : StoreOwner
{
    private DomliTheHumbleStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Domli the Humble";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  116;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<DwarfRace>();
}