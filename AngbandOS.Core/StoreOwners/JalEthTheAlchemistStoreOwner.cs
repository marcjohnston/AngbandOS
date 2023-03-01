[Serializable]
internal class JalEthTheAlchemistStoreOwner : StoreOwner
{
    private JalEthTheAlchemistStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Jal-Eth the Alchemist";
    public override int MaxCost =>  15000;
    public override int MinInflate =>  111;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<ElfRace>();
}