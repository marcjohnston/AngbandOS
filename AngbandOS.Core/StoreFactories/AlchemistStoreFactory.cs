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
    private AlchemistStoreFactory(Game game) : base(game) { }

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

    protected override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(RestoreCharismaPotionItemFactory), 2),
        (nameof(RestoreConstitutionPotionItemFactory), 2),
        (nameof(RestoreDexterityPotionItemFactory), 2),
        (nameof(RestoreIntelligencePotionItemFactory), 2),
        (nameof(RestoreStrengthPotionItemFactory), 2),
        (nameof(RestoreWisdomPotionItemFactory), 2),
        (nameof(DetectInvisibleScrollItemFactory), 1),
        (nameof(EnchantArmorScrollItemFactory), 3),
        (nameof(EnchantWeaponToDamScrollItemFactory), 1),
        (nameof(EnchantWeaponToHitScrollItemFactory), 1),
        (nameof(IdentifyScrollItemFactory), 6),
        (nameof(LightScrollItemFactory), 2),
        (nameof(MagicMappingScrollItemFactory), 1),
        (nameof(MonsterConfusionScrollItemFactory), 1),
        (nameof(ObjectDetectionScrollItemFactory), 1),
        (nameof(PhaseDoorScrollItemFactory), 2),
        (nameof(RechargingScrollItemFactory), 2),
        (nameof(SatisfyHungerScrollItemFactory), 4),
        (nameof(SpecialIdentifyScrollItemFactory), 2),
        (nameof(TeleportationScrollItemFactory), 3),
        (nameof(TrapDetectionScrollItemFactory), 1),
        (nameof(TreasureDetectionScrollItemFactory), 1),
        (nameof(WordOfRecallScrollItemFactory), 4),
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