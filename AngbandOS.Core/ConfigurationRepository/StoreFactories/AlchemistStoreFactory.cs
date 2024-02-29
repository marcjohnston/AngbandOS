// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal partial class AlchemistStoreFactory : StoreFactory
{
    private AlchemistStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] ShopkeeperNames => new string[]
    {
        nameof(MauserTheChemistShopkeeper),
        nameof(WizzleTheChaoticShopkeeper),
        nameof(KakalrakakalShopkeeper),
        nameof(JalEthTheAlchemistShopkeeper),
        nameof(FanelathTheCautiousShopkeeper),
        nameof(RuncieTheInsaneShopkeeper),
        nameof(GrumbleworthShopkeeper),
        nameof(FlitterShopkeeper),
        nameof(XarillusShopkeeper),
        nameof(EgbertTheOldShopkeeper),
        nameof(ValindraTheProudShopkeeper),
        nameof(TaenTheAlchemistShopkeeper),
        nameof(CaydTheSweetShopkeeper),
        nameof(FulirTheDarkShopkeeper),
        nameof(DomliTheHumbleShopkeeper),
        nameof(YaarjukkaDemonspawnShopkeeper),
        nameof(GelaraldorTheHerbmasterShopkeeper),
        nameof(OlelaldanTheWiseShopkeeper),
        nameof(FthogloTheDemonicistShopkeeper),
        nameof(DridashTheAlchemistShopkeeper)
    };

    protected override string TileName => nameof(AlchemistStoreTile);

    protected override StoreStockManifestDefinition[]? StoreStockManifestDefinitions => new[]
    {
        new StoreStockManifestDefinition(nameof(RestoreCharismaPotionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(RestoreConstitutionPotionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(RestoreDexterityPotionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(RestoreIntelligencePotionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(RestoreStrengthPotionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(RestoreWisdomPotionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(DetectInvisibleScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(EnchantArmorScrollItemFactory), 3),
        new StoreStockManifestDefinition(nameof(EnchantWeaponToDamScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(EnchantWeaponToHitScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(IdentifyScrollItemFactory), 6),
        new StoreStockManifestDefinition(nameof(LightScrollItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MagicMappingScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(MonsterConfusionScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(ObjectDetectionScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(PhaseDoorScrollItemFactory), 2),
        new StoreStockManifestDefinition(nameof(RechargingScrollItemFactory), 2),
        new StoreStockManifestDefinition(nameof(SatisfyHungerScrollItemFactory), 4),
        new StoreStockManifestDefinition(nameof(SpecialIdentifyScrollItemFactory), 2),
        new StoreStockManifestDefinition(nameof(TeleportationScrollItemFactory), 3),
        new StoreStockManifestDefinition(nameof(TrapDetectionScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(TreasureDetectionScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(WordOfRecallScrollItemFactory), 4),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for scrolls and potions of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(ScrollsOfValueItemFilter),
        nameof(PotionsOfValueItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(RestorationStoreCommand);
}