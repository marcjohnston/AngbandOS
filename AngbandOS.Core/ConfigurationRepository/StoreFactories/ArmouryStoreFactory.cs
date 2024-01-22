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

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(KonDarTheUglyStoreOwner),
        nameof(DargLowTheGrimStoreOwner),
        nameof(DecadoTheHandsomeStoreOwner),
        nameof(EloDragonscaleStoreOwner),
        nameof(DelicatusStoreOwner),
        nameof(GruceTheHugeStoreOwner),
        nameof(AnimusStoreOwner),
        nameof(MalvusStoreOwner),
        nameof(SelaxisStoreOwner),
        nameof(DeathchillStoreOwner),
        nameof(DriosTheFaintStoreOwner),
        nameof(BathricTheColdStoreOwner),
        nameof(VengellaTheCruelStoreOwner),
        nameof(WyranaTheMightyStoreOwner),
        nameof(YojoIIStoreOwner),
        nameof(RanalarTheSweetStoreOwner),
        nameof(HorbagTheUncleanStoreOwner),
        nameof(ElelenTheTelepathStoreOwner),
        nameof(IsedreliasStoreOwner),
        nameof(VegnarOneEyeStoreOwner),
        nameof(RodishTheChaoticStoreOwner),
        nameof(HesinSwordmasterStoreOwner),
        nameof(ElvererithTheCheatStoreOwner),
        nameof(ZzathathTheImpStoreOwner)
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
    protected override string? AdvertisedStoreCommand4Name => nameof(EnchantArmorStoreCommand);
}
