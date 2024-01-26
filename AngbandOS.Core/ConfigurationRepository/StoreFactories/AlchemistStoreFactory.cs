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
    public override ColourEnum Colour => ColourEnum.Blue;
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
            new StockStoreInventoryItem(typeof(ScrollDetectInvisible)),
            new StockStoreInventoryItem(typeof(ScrollEnchantArmor), 3),
            new StockStoreInventoryItem(typeof(ScrollEnchantWeaponToDam)),
            new StockStoreInventoryItem(typeof(ScrollEnchantWeaponToHit)),
            new StockStoreInventoryItem(typeof(ScrollIdentify), 6),
            new StockStoreInventoryItem(typeof(ScrollLight), 2),
            new StockStoreInventoryItem(typeof(ScrollMagicMapping)),
            new StockStoreInventoryItem(typeof(ScrollMonsterConfusion)),
            new StockStoreInventoryItem(typeof(ScrollObjectDetection)),
            new StockStoreInventoryItem(typeof(ScrollPhaseDoor), 2),
            new StockStoreInventoryItem(typeof(ScrollRecharging), 2),
            new StockStoreInventoryItem(typeof(ScrollSatisfyHunger), 4),
            new StockStoreInventoryItem(typeof(ScrollSpecialIdentify), 2),
            new StockStoreInventoryItem(typeof(ScrollTeleportation), 3),
            new StockStoreInventoryItem(typeof(ScrollTrapDetection)),
            new StockStoreInventoryItem(typeof(ScrollTreasureDetection)),
            new StockStoreInventoryItem(typeof(ScrollWordOfRecall), 4),
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