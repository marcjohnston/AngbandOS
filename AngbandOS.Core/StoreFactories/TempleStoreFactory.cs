﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal partial class TempleStoreFactory : StoreFactory
{
    private TempleStoreFactory(Game game) : base(game) { }

    protected override string TileName => nameof(TempleStoreTile);

    protected override string[] ShopkeeperNames => new string[]
    {
        nameof(LudwigTheHumbleShopkeeper),
        nameof(GunnarThePaladinShopkeeper),
        nameof(SirParsivalThePureShopkeeper),
        nameof(AsenathTheHolyShopkeeper),
        nameof(McKinnonShopkeeper),
        nameof(MistressChastityShopkeeper),
        nameof(HashnikTheDruidShopkeeper),
        nameof(FinakShopkeeper),
        nameof(KrikkikShopkeeper),
        nameof(MorivalTheWildShopkeeper),
        nameof(HoshakTheDarkShopkeeper),
        nameof(AtalTheWiseShopkeeper),
        nameof(IbeniddTheChasteShopkeeper),
        nameof(EridishShopkeeper),
        nameof(VrudushTheShamanShopkeeper),
        nameof(HaobTheBerserkerShopkeeper),
        nameof(ProogdishTheYouthfullShopkeeper),
        nameof(LumwiseTheMadShopkeeper),
        nameof(MuirtTheVirtuousShopkeeper),
        nameof(DardobardTheWeakShopkeeper)
    };

    protected override StoreStockManifestDefinition[]? StoreStockManifestDefinitions => new[]
    {
        new StoreStockManifestDefinition(nameof(BallAndChainHaftedWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(FlailHaftedWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(LeadFilledMaceHaftedWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(LucerneHammerHaftedWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(MaceHaftedWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MorningStarHaftedWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(QuarterstaffHaftedWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(WarHammerHaftedWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(WhipHaftedWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(CommonPrayerLifeBookItemFactory), 4),
        new StoreStockManifestDefinition(nameof(HighMassLifeBookItemFactory), 4),
        new StoreStockManifestDefinition(nameof(CureCriticalWoundsPotionItemFactory), 4),
        new StoreStockManifestDefinition(nameof(CureLightWoundsPotionItemFactory)),
        new StoreStockManifestDefinition(nameof(CureSeriousWoundsPotionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(HeroismPotionItemFactory)),
        new StoreStockManifestDefinition(nameof(RestoreLifeLevelsPotionItemFactory), 6),
        new StoreStockManifestDefinition(nameof(BlessingScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(HolyChantScrollItemFactory)),
        new StoreStockManifestDefinition(nameof(RemoveCurseScrollItemFactory), 3),
        new StoreStockManifestDefinition(nameof(SpecialRemoveCurseScrollItemFactory), 2),
        new StoreStockManifestDefinition(nameof(WordOfRecallScrollItemFactory), 6),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for life books, scrolls, potions, hafted weapons, blessed pole arms and blessed swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(LifeBooksOfValueItemFilter),
        nameof(ScrollsOfValueItemFilter),
        nameof(PotionsOfValueItemFilter),
        nameof(HaftedItemsOfValueFilter),
        nameof(BlessedPolearmsOfValueItemFilter),
        nameof(BlessedSwordsOfValueItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(RemoveCurseStoreCommand);
    protected override string? AdvertisedStoreCommand5Name => nameof(SacrificeStoreCommand);
}