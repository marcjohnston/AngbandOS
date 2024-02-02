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

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(MauserTheChemistStoreOwner),
        nameof(WizzleTheChaoticStoreOwner),
        nameof(KakalrakakalStoreOwner),
        nameof(JalEthTheAlchemistStoreOwner),
        nameof(FanelathTheCautiousStoreOwner),
        nameof(RuncieTheInsaneStoreOwner),
        nameof(GrumbleworthStoreOwner),
        nameof(FlitterStoreOwner),
        nameof(XarillusStoreOwner),
        nameof(EgbertTheOldStoreOwner),
        nameof(ValindraTheProudStoreOwner),
        nameof(TaenTheAlchemistStoreOwner),
        nameof(CaydTheSweetStoreOwner),
        nameof(FulirTheDarkStoreOwner),
        nameof(DomliTheHumbleStoreOwner),
        nameof(YaarjukkaDemonspawnStoreOwner),
        nameof(GelaraldorTheHerbmasterStoreOwner),
        nameof(OlelaldanTheWiseStoreOwner),
        nameof(FthogloTheDemonicistStoreOwner),
        nameof(DridashTheAlchemistStoreOwner)
    };

    public override string FeatureType => "Alchemist";
    public override ColorEnum Color => ColorEnum.Blue;
    protected override string SymbolName => nameof(NumberFiveSymbol);
    public override string Description => "Alchemy Shop";

    public override StoreStockManifest[]? StoreStockManifests => new[]
    {
        new StoreStockManifest(typeof(RestoreCharismaPotionItemFactory), 2),
        new StoreStockManifest(typeof(RestoreConstitutionPotionItemFactory), 2),
        new StoreStockManifest(typeof(RestoreDexterityPotionItemFactory), 2),
        new StoreStockManifest(typeof(RestoreIntelligencePotionItemFactory), 2),
        new StoreStockManifest(typeof(RestoreStrengthPotionItemFactory), 2),
        new StoreStockManifest(typeof(RestoreWisdomPotionItemFactory), 2),
        new StoreStockManifest(typeof(DetectInvisibleScrollItemFactory)),
        new StoreStockManifest(typeof(EnchantArmorScrollItemFactory), 3),
        new StoreStockManifest(typeof(EnchantWeaponToDamScrollItemFactory)),
        new StoreStockManifest(typeof(EnchantWeaponToHitScrollItemFactory)),
        new StoreStockManifest(typeof(IdentifyScrollItemFactory), 6),
        new StoreStockManifest(typeof(LightScrollItemFactory), 2),
        new StoreStockManifest(typeof(MagicMappingScrollItemFactory)),
        new StoreStockManifest(typeof(MonsterConfusionScrollItemFactory)),
        new StoreStockManifest(typeof(ObjectDetectionScrollItemFactory)),
        new StoreStockManifest(typeof(PhaseDoorScrollItemFactory), 2),
        new StoreStockManifest(typeof(RechargingScrollItemFactory), 2),
        new StoreStockManifest(typeof(SatisfyHungerScrollItemFactory), 4),
        new StoreStockManifest(typeof(SpecialIdentifyScrollItemFactory), 2),
        new StoreStockManifest(typeof(TeleportationScrollItemFactory), 3),
        new StoreStockManifest(typeof(TrapDetectionScrollItemFactory)),
        new StoreStockManifest(typeof(TreasureDetectionScrollItemFactory)),
        new StoreStockManifest(typeof(WordofRecallScrollItemFactory), 4),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for scrolls and potions of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(ScrollItemFilter),
        nameof(PotionItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(RestorationStoreCommand);
}