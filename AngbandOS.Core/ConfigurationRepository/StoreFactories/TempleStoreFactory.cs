// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal partial class TempleStoreFactory : StoreFactory
{
    private TempleStoreFactory(SaveGame saveGame) : base(saveGame) { }

    public override string FeatureType => "Temple";
    public override ColourEnum Colour => ColourEnum.Green;
    protected override string SymbolName => nameof(NumberFourSymbol);

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(LudwigTheHumbleStoreOwner),
        nameof(GunnarThePaladinStoreOwner),
        nameof(SirParsivalThePureStoreOwner),
        nameof(AsenathTheHolyStoreOwner),
        nameof(McKinnonStoreOwner),
        nameof(MistressChastityStoreOwner),
        nameof(HashnikTheDruidStoreOwner),
        nameof(FinakStoreOwner),
        nameof(KrikkikStoreOwner),
        nameof(MorivalTheWildStoreOwner),
        nameof(HoshakTheDarkStoreOwner),
        nameof(AtalTheWiseStoreOwner),
        nameof(IbeniddTheChasteStoreOwner),
        nameof(EridishStoreOwner),
        nameof(VrudushTheShamanStoreOwner),
        nameof(HaobTheBerserkerStoreOwner),
        nameof(ProogdishTheYouthfullStoreOwner),
        nameof(LumwiseTheMadStoreOwner),
        nameof(MuirtTheVirtuousStoreOwner),
        nameof(DardobardTheWeakStoreOwner)
    };

    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(HaftedBallAndChain), 2),
            new StockStoreInventoryItem(typeof(HaftedFlail)),
            new StockStoreInventoryItem(typeof(HaftedLeadFilledMace)),
            new StockStoreInventoryItem(typeof(HaftedLucerneHammer)),
            new StockStoreInventoryItem(typeof(HaftedMace), 2),
            new StockStoreInventoryItem(typeof(HaftedMorningStar)),
            new StockStoreInventoryItem(typeof(HaftedQuarterstaff)),
            new StockStoreInventoryItem(typeof(HaftedWarHammer), 2),
            new StockStoreInventoryItem(typeof(HaftedWhip), 2),
            new StockStoreInventoryItem(typeof(CommonPrayerLifeBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(HighMassLifeBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(CureCriticalWoundsPotionItemFactory), 4),
            new StockStoreInventoryItem(typeof(CureLightWoundsPotionItemFactory)),
            new StockStoreInventoryItem(typeof(CureSeriousWoundsPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(HeroismPotionItemFactory)),
            new StockStoreInventoryItem(typeof(RestoreLifeLevelsPotionItemFactory), 6),
            new StockStoreInventoryItem(typeof(ScrollBlessing)),
            new StockStoreInventoryItem(typeof(ScrollHolyChant)),
            new StockStoreInventoryItem(typeof(ScrollRemoveCurse), 3),
            new StockStoreInventoryItem(typeof(ScrollSpecialRemoveCurse), 2),
            new StockStoreInventoryItem(typeof(ScrollWordOfRecall), 6),
        };
    }

    /// <summary>
    /// Returns the name of the item matching criteria for life books, scrolls, potions, hafted weapons, blessed pole arms and blessed swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(LifeBookItemMatchingCriteria),
        nameof(ScrollItemMatchingCriteria),
        nameof(PotionItemMatchingCriteria),
        nameof(HaftedItemMatchingCriteria),
        nameof(BlessedPolearmItemMatchingCriteria),
        nameof(BlessedSwordItemMatchingCriteria)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(RemoveCurseStoreCommand);
    protected override string? AdvertisedStoreCommand5Name => nameof(SacrificeStoreCommand);
}
