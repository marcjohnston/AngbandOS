// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class ArmouryStoreFactory : StoreFactory
{
    private ArmouryStoreFactory(SaveGame saveGame) : base(saveGame) { }

    public override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(KonDarTheUglyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DargLowTheGrimStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DecadoTheHandsomeStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EloDragonscaleStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DelicatusStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GruceTheHugeStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AnimusStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MalvusStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SelaxisStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DeathchillStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DriosTheFaintStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(BathricTheColdStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(VengellaTheCruelStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(WyranaTheMightyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(YojoIIStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(RanalarTheSweetStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HorbagTheUncleanStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ElelenTheTelepathStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(IsedreliasStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(VegnarOneEyeStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(RodishTheChaoticStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HesinSwordmasterStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ElvererithTheCheatStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ZzathathTheImpStoreOwner))
    };

    public override string FeatureType => "Armoury";
    public override ColourEnum Colour => ColourEnum.Grey;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(NumberTwoSymbol));

    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(HardLeatherBootsArmorItemFactory), 4),
            new StockStoreInventoryItem(typeof(SoftLeatherBootsArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(GauntletGlovesArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(LeatherGlovesArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(AugmentedChainMailHardArmorItemFactory)),
            new StockStoreInventoryItem(typeof(BarChainMailHardArmorItemFactory)),
            new StockStoreInventoryItem(typeof(ChainMailHardArmorItemFactory), 4),
            new StockStoreInventoryItem(typeof(DoubleChainMailHardArmorItemFactory)),
            new StockStoreInventoryItem(typeof(MetalBrigandineHardArmorItemFactory)),
            new StockStoreInventoryItem(typeof(MetalScaleMailHardArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(HelmHardLeatherCap), 4),
            new StockStoreInventoryItem(typeof(HelmIronHelm)),
            new StockStoreInventoryItem(typeof(HelmMetalCap)),
            new StockStoreInventoryItem(typeof(ShieldLargeLeatherShield)),
            new StockStoreInventoryItem(typeof(ShieldSmallLeatherShield), 4),
            new StockStoreInventoryItem(typeof(ShieldSmallMetalShield)),
            new StockStoreInventoryItem(typeof(HardLeatherSoftArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(HardStuddedLeatherSoftArmorItemFactory), 2),
            new StockStoreInventoryItem(typeof(LeatherScaleMailSoftArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(RobeSoftArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(SoftLeatherSoftArmorItemFactory), 4),
        };
    }

    public override bool ItemMatches(Item item)
    {
        switch (item.Factory)
        {
            case BootsArmorItemFactory _:
            case GlovesArmorItemFactory _:
            case CrownArmorItemFactory _:
            case HelmItemClass _:
            case ShieldItemClass _:
            case CloakArmorItemFactory _:
            case SoftArmorItemFactory _:
            case HardArmorItemFactory _:
            case DragonScaleMailArmorItemFactory _:
                return item.Value() > 0;
            default:
                return false;
        }
    }
    public override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(EnchantArmorStoreCommand));
}
