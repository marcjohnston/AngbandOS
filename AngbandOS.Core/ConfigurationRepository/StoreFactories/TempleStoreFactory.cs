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
    public override ColorEnum Color => ColorEnum.Green;
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

    public override StockStoreInventoryItem[]? GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(BallAndChainHaftedWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(FlailHaftedWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(LeadFilledMaceHaftedWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(LucerneHammerHaftedWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(MaceHaftedWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(MorningStarHaftedWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(QuarterstaffHaftedWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(WarHammerHaftedWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(WhipHaftedWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(CommonPrayerLifeBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(HighMassLifeBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(CureCriticalWoundsPotionItemFactory), 4),
            new StockStoreInventoryItem(typeof(CureLightWoundsPotionItemFactory)),
            new StockStoreInventoryItem(typeof(CureSeriousWoundsPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(HeroismPotionItemFactory)),
            new StockStoreInventoryItem(typeof(RestoreLifeLevelsPotionItemFactory), 6),
            new StockStoreInventoryItem(typeof(BlessingScrollItemFactory)),
            new StockStoreInventoryItem(typeof(HolyChantScrollItemFactory)),
            new StockStoreInventoryItem(typeof(RemoveCurseScrollItemFactory), 3),
            new StockStoreInventoryItem(typeof(SpecialRemoveCurseScrollItemFactory), 2),
            new StockStoreInventoryItem(typeof(WordofRecallScrollItemFactory), 6),
        };
    }

    /// <summary>
    /// Returns the name of the item matching criteria for life books, scrolls, potions, hafted weapons, blessed pole arms and blessed swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(LifeBookItemFilter),
        nameof(ScrollItemFilter),
        nameof(PotionItemFilter),
        nameof(HaftedItemFilter),
        nameof(BlessedPolearmItemFilter),
        nameof(BlessedSwordItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(RemoveCurseStoreCommand);
    protected override string? AdvertisedStoreCommand5Name => nameof(SacrificeStoreCommand);
}
