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

    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(RestoreCharismaPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreConstitutionPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreDexterityPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreIntelligencePotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreStrengthPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(RestoreWisdomPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(DetectInvisibleScrollItemFactory)),
            new StockStoreInventoryItem(typeof(EnchantArmorScrollItemFactory), 3),
            new StockStoreInventoryItem(typeof(EnchantWeaponToDamScrollItemFactory)),
            new StockStoreInventoryItem(typeof(EnchantWeaponToHitScrollItemFactory)),
            new StockStoreInventoryItem(typeof(IdentifyScrollItemFactory), 6),
            new StockStoreInventoryItem(typeof(LightScrollItemFactory), 2),
            new StockStoreInventoryItem(typeof(MagicMappingScrollItemFactory)),
            new StockStoreInventoryItem(typeof(MonsterConfusionScrollItemFactory)),
            new StockStoreInventoryItem(typeof(ObjectDetectionScrollItemFactory)),
            new StockStoreInventoryItem(typeof(PhaseDoorScrollItemFactory), 2),
            new StockStoreInventoryItem(typeof(RechargingScrollItemFactory), 2),
            new StockStoreInventoryItem(typeof(SatisfyHungerScrollItemFactory), 4),
            new StockStoreInventoryItem(typeof(SpecialIdentifyScrollItemFactory), 2),
            new StockStoreInventoryItem(typeof(TeleportationScrollItemFactory), 3),
            new StockStoreInventoryItem(typeof(TrapDetectionScrollItemFactory)),
            new StockStoreInventoryItem(typeof(TreasureDetectionScrollItemFactory)),
            new StockStoreInventoryItem(typeof(WordofRecallScrollItemFactory), 4),
        };
    }

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