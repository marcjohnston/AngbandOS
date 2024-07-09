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

    protected override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(BallAndChainHaftedWeaponItemFactory), 2),
        (nameof(FlailHaftedWeaponItemFactory), 1),
        (nameof(LeadFilledMaceHaftedWeaponItemFactory), 1),
        (nameof(LucerneHammerHaftedWeaponItemFactory), 1),
        (nameof(MaceHaftedWeaponItemFactory), 2),
        (nameof(MorningStarHaftedWeaponItemFactory), 1),
        (nameof(QuarterstaffHaftedWeaponItemFactory), 1),
        (nameof(WarHammerHaftedWeaponItemFactory), 2),
        (nameof(WhipHaftedWeaponItemFactory), 2),
        (nameof(CommonPrayerLifeBookItemFactory), 4),
        (nameof(HighMassLifeBookItemFactory), 4),
        (nameof(CureCriticalWoundsPotionItemFactory), 4),
        (nameof(CureLightWoundsPotionItemFactory), 1),
        (nameof(CureSeriousWoundsPotionItemFactory), 2),
        (nameof(HeroismPotionItemFactory), 1),
        (nameof(RestoreLifeLevelsPotionItemFactory), 6),
        (nameof(BlessingScrollItemFactory), 1),
        (nameof(HolyChantScrollItemFactory), 1),
        (nameof(RemoveCurseScrollItemFactory), 3),
        (nameof(SpecialRemoveCurseScrollItemFactory), 2),
        (nameof(WordOfRecallScrollItemFactory), 6),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for life books, scrolls, potions, hafted weapons, blessed pole arms and blessed swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(LifeBooksOfValueItemFilter),
        nameof(ScrollsOfValueItemFilter),
        nameof(PotionsOfValueItemFilter),
        nameof(HaftedWeaponsOfValueItemFilter),
        nameof(BlessedPolearmsOfValueItemFilter),
        nameof(BlessedSwordsOfValueItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(RemoveCurseStoreCommand);
    protected override string? AdvertisedStoreCommand5Name => nameof(SacrificeStoreCommand);
}
