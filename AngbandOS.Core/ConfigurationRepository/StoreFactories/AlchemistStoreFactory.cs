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
        new StoreStockManifestDefinition(nameof(WordofRecallScrollItemFactory), 4),
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