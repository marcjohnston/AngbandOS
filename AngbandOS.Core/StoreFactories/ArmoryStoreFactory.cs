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
    private ArmoryStoreFactory(Game game) : base(game) { }

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

    protected override string TileName => nameof(ArmoryStoreTile);

    protected override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(HardLeatherBootsArmorItemFactory), 4),
        (nameof(SoftLeatherBootsArmorItemFactory), 2),
        (nameof(GauntletGlovesArmorItemFactory), 2),
        (nameof(LeatherGlovesArmorItemFactory), 3),
        (nameof(AugmentedChainMailHardArmorItemFactory), 1),
        (nameof(BarChainMailHardArmorItemFactory), 1),
        (nameof(ChainMailHardArmorItemFactory), 4),
        (nameof(DoubleChainMailHardArmorItemFactory), 1),
        (nameof(MetalBrigandineHardArmorItemFactory), 1),
        (nameof(MetalScaleMailHardArmorItemFactory), 2),
        (nameof(HardLeatherCapHelmArmorItemFactory), 4),
        (nameof(IronHelmArmorItemFactory), 1),
        (nameof(MetalCapHelmArmorFactory), 1),
        (nameof(LargeLeatherShieldArmorItemFactory), 1),
        (nameof(SmallLeatherShieldArmorItemFactory), 4),
        (nameof(SmallMetalShieldArmorItemFactory), 1),
        (nameof(HardLeatherSoftArmorItemFactory), 3),
        (nameof(HardStuddedLeatherSoftArmorItemFactory), 2),
        (nameof(LeatherScaleMailSoftArmorItemFactory), 3),
        (nameof(RobeSoftArmorItemFactory), 3),
        (nameof(SoftLeatherSoftArmorItemFactory), 4),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
{
        nameof(BootsOfValueItemFilter),
        nameof(GlovesOfValueItemFilter),
        nameof(CrownsOfValueItemFilter),
        nameof(HelmsOfValueFilter),
        nameof(ShieldsOfValueItemFilter),
        nameof(CloaksOfValueItemFilter),
        nameof(SoftArmorOfValueItemFilter),
        nameof(HardArmorOfValueItemFilter),
        nameof(DragonScaleMailOfValueItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(EnchantArmorStoreCommand);
}
