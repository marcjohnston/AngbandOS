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

    public override StoreStockManifest[]? StoreStockManifests => new[]
    {
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BallAndChainHaftedWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(FlailHaftedWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LeadFilledMaceHaftedWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LucerneHammerHaftedWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MaceHaftedWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MorningStarHaftedWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(QuarterstaffHaftedWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(WarHammerHaftedWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(WhipHaftedWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(CommonPrayerLifeBookItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(HighMassLifeBookItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(CureCriticalWoundsPotionItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(CureLightWoundsPotionItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(CureSeriousWoundsPotionItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(HeroismPotionItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RestoreLifeLevelsPotionItemFactory)), 6),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BlessingScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(HolyChantScrollItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RemoveCurseScrollItemFactory)), 3),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SpecialRemoveCurseScrollItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(WordofRecallScrollItemFactory)), 6),
    };

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
