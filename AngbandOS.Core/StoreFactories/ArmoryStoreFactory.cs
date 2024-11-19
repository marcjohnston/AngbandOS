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
        (nameof(HardLeatherBootsItemFactory), 4),
        (nameof(SoftLeatherBootsItemFactory), 2),
        (nameof(GauntletGlovesItemFactory), 2),
        (nameof(LeatherGlovesItemFactory), 3),
        (nameof(AugmentedChainMailHardItemFactory), 1),
        (nameof(BarChainMailHardItemFactory), 1),
        (nameof(ChainMailHardItemFactory), 4),
        (nameof(DoubleChainMailHardItemFactory), 1),
        (nameof(MetalBrigandineHardItemFactory), 1),
        (nameof(MetalScaleMailHardItemFactory), 2),
        (nameof(HardLeatherCapHelmItemFactory), 4),
        (nameof(IronHelmItemFactory), 1),
        (nameof(MetalCapHelmItemFactory), 1),
        (nameof(LargeLeatherShieldItemFactory), 1),
        (nameof(SmallLeatherShieldItemFactory), 4),
        (nameof(SmallMetalShieldItemFactory), 1),
        (nameof(HardLeatherSoftItemFactory), 3),
        (nameof(HardStuddedLeatherSoftItemFactory), 2),
        (nameof(LeatherScaleMailSoftItemFactory), 3),
        (nameof(RobeSoftItemFactory), 3),
        (nameof(SoftLeatherSoftItemFactory), 4),
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
