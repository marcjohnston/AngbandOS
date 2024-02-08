// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class ArmoryStoreFactory : StoreFactory
{
    private ArmoryStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] ShopkeeperNames => new string[]
    {
        nameof(KonDarTheUglyShopkeeper),
        nameof(DargLowTheGrimShopkeeper),
        nameof(DecadoTheHandsomeShopkeeper),
        nameof(EloDragonscaleShopkeeper),
        nameof(DelicatusShopkeeper),
        nameof(GruceTheHugeShopkeeper),
        nameof(AnimusShopkeeper),
        nameof(MalvusShopkeeper),
        nameof(SelaxisShopkeeper),
        nameof(DeathchillShopkeeper),
        nameof(DriosTheFaintShopkeeper),
        nameof(BathricTheColdShopkeeper),
        nameof(VengellaTheCruelShopkeeper),
        nameof(WyranaTheMightyShopkeeper),
        nameof(YojoIIShopkeeper),
        nameof(RanalarTheSweetShopkeeper),
        nameof(HorbagTheUncleanShopkeeper),
        nameof(ElelenTheTelepathShopkeeper),
        nameof(IsedreliasShopkeeper),
        nameof(VegnarOneEyeShopkeeper),
        nameof(RodishTheChaoticShopkeeper),
        nameof(HesinSwordmasterShopkeeper),
        nameof(ElvererithTheCheatShopkeeper),
        nameof(ZzathathTheImpShopkeeper)
    };

    protected override string TileName => "Armory";

    protected override StoreStockManifestDefinition[]? StoreStockManifestDefinitions => new[]
    {
        new StoreStockManifestDefinition(nameof(HardLeatherBootsArmorItemFactory), 4),
        new StoreStockManifestDefinition(nameof(SoftLeatherBootsArmorItemFactory), 2),
        new StoreStockManifestDefinition(nameof(GauntletGlovesArmorItemFactory), 2),
        new StoreStockManifestDefinition(nameof(LeatherGlovesArmorItemFactory), 3),
        new StoreStockManifestDefinition(nameof(AugmentedChainMailHardArmorItemFactory)),
        new StoreStockManifestDefinition(nameof(BarChainMailHardArmorItemFactory)),
        new StoreStockManifestDefinition(nameof(ChainMailHardArmorItemFactory), 4),
        new StoreStockManifestDefinition(nameof(DoubleChainMailHardArmorItemFactory)),
        new StoreStockManifestDefinition(nameof(MetalBrigandineHardArmorItemFactory)),
        new StoreStockManifestDefinition(nameof(MetalScaleMailHardArmorItemFactory), 2),
        new StoreStockManifestDefinition(nameof(HardLeatherCapHelmArmorItemFactory), 4),
        new StoreStockManifestDefinition(nameof(IronHelmArmorItemFactory)),
        new StoreStockManifestDefinition(nameof(MetalCapHelmArmorFactory)),
        new StoreStockManifestDefinition(nameof(LargeLeatherShieldArmorItemFactory)),
        new StoreStockManifestDefinition(nameof(SmallLeatherShieldArmorItemFactory), 4),
        new StoreStockManifestDefinition(nameof(SmallMetalShieldArmorItemFactory)),
        new StoreStockManifestDefinition(nameof(HardLeatherSoftArmorItemFactory), 3),
        new StoreStockManifestDefinition(nameof(HardStuddedLeatherSoftArmorItemFactory), 2),
        new StoreStockManifestDefinition(nameof(LeatherScaleMailSoftArmorItemFactory), 3),
        new StoreStockManifestDefinition(nameof(RobeSoftArmorItemFactory), 3),
        new StoreStockManifestDefinition(nameof(SoftLeatherSoftArmorItemFactory), 4),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
{
        nameof(BootsArmorItemFilter),
        nameof(GlovesArmorItemFilter),
        nameof(CrownArmorItemFilter),
        nameof(HelmItemFilter),
        nameof(ShieldItemFilter),
        nameof(CloakArmorItemFilter),
        nameof(SoftArmorItemFilter),
        nameof(HardArmorItemFilter),
        nameof(DragonScaleMailItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(EnchantArmorStoreCommand);
}
