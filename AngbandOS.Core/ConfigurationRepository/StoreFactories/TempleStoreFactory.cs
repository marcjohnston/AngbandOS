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

    public override StoreStockManifest[]? GetStoreTable()
    {
        return new[]
        {
            new StoreStockManifest(typeof(BallAndChainHaftedWeaponItemFactory), 2),
            new StoreStockManifest(typeof(FlailHaftedWeaponItemFactory)),
            new StoreStockManifest(typeof(LeadFilledMaceHaftedWeaponItemFactory)),
            new StoreStockManifest(typeof(LucerneHammerHaftedWeaponItemFactory)),
            new StoreStockManifest(typeof(MaceHaftedWeaponItemFactory), 2),
            new StoreStockManifest(typeof(MorningStarHaftedWeaponItemFactory)),
            new StoreStockManifest(typeof(QuarterstaffHaftedWeaponItemFactory)),
            new StoreStockManifest(typeof(WarHammerHaftedWeaponItemFactory), 2),
            new StoreStockManifest(typeof(WhipHaftedWeaponItemFactory), 2),
            new StoreStockManifest(typeof(CommonPrayerLifeBookItemFactory), 4),
            new StoreStockManifest(typeof(HighMassLifeBookItemFactory), 4),
            new StoreStockManifest(typeof(CureCriticalWoundsPotionItemFactory), 4),
            new StoreStockManifest(typeof(CureLightWoundsPotionItemFactory)),
            new StoreStockManifest(typeof(CureSeriousWoundsPotionItemFactory), 2),
            new StoreStockManifest(typeof(HeroismPotionItemFactory)),
            new StoreStockManifest(typeof(RestoreLifeLevelsPotionItemFactory), 6),
            new StoreStockManifest(typeof(BlessingScrollItemFactory)),
            new StoreStockManifest(typeof(HolyChantScrollItemFactory)),
            new StoreStockManifest(typeof(RemoveCurseScrollItemFactory), 3),
            new StoreStockManifest(typeof(SpecialRemoveCurseScrollItemFactory), 2),
            new StoreStockManifest(typeof(WordofRecallScrollItemFactory), 6),
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
