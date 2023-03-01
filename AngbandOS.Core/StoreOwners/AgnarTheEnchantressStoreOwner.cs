[Serializable]
internal class AgnarTheEnchantressStoreOwner : StoreOwner
{
    private AgnarTheEnchantressStoreOwner(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string OwnerName => "Agnar the Enchantress";
    public override int MaxCost =>  30000;
    public override int MinInflate =>  110;
    public override Race? OwnerRace =>  SaveGame.SingletonRepository.Races.Get<HumanRace>();
}