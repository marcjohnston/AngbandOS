// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmoryStoreFactory : StoreFactoryGameConfiguration
{

    public override string[] ShopkeeperNames => new string[]
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

    public override string TileName => nameof(ArmoryStoreTile);

    public override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(HardLeatherBootsItemFactory), 4),
        (nameof(SoftLeatherBootsItemFactory), 2),
        (nameof(GauntletGlovesItemFactory), 2),
        (nameof(LeatherGlovesItemFactory), 3),
        (nameof(AugmentedChainMailHardArmorItemFactory), 1),
        (nameof(BarChainMailHardArmorItemFactory), 1),
        (nameof(ChainMailHardArmorItemFactory), 4),
        (nameof(DoubleChainMailHardArmorItemFactory), 1),
        (nameof(MetalBrigandineHardArmorItemFactory), 1),
        (nameof(MetalScaleMailHardArmorItemFactory), 2),
        (nameof(HardLeatherCapHelmItemFactory), 4),
        (nameof(IronHelmItemFactory), 1),
        (nameof(MetalCapHelmItemFactory), 1),
        (nameof(LargeLeatherShieldItemFactory), 1),
        (nameof(SmallLeatherShieldItemFactory), 4),
        (nameof(SmallMetalShieldItemFactory), 1),
        (nameof(HardLeatherSoftArmorItemFactory), 3),
        (nameof(HardStuddedLeatherSoftArmorItemFactory), 2),
        (nameof(LeatherScaleMailSoftArmorItemFactory), 3),
        (nameof(RobeSoftArmorItemFactory), 3),
        (nameof(SoftLeatherSoftArmorItemFactory), 4),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    public override string[] ItemFilterNames => new string[]
{
        nameof(ItemFiltersEnum.BootsOfValueItemFilter),
        nameof(ItemFiltersEnum.GlovesOfValueItemFilter),
        nameof(ItemFiltersEnum.CrownsOfValueItemFilter),
        nameof(ItemFiltersEnum.GlovesOfValueItemFilter),
        nameof(ItemFiltersEnum.HelmsOfValueItemFilter),
        nameof(ItemFiltersEnum.ShieldsOfValueItemFilter),
        nameof(ItemFiltersEnum.CloaksOfValueItemFilter),
        nameof(ItemFiltersEnum.SoftArmorOfValueItemFilter),
        nameof(ItemFiltersEnum.HardArmorOfValueItemFilter),
        nameof(ItemFiltersEnum.DragonScaleMailOfValueItemFilter)
    };

    public override string? AdvertisedStoreCommand4Name => nameof(EnchantArmorStoreCommand);
}
