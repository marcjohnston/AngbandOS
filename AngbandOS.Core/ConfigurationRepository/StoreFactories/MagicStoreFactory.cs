// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class MagicStoreFactory : StoreFactory
{
    private MagicStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(SkidneyTheSorcererStoreOwner),
        nameof(BuggerbyTheGreatStoreOwner),
        nameof(KyriaTheIllusionistStoreOwner),
        nameof(NikkiTheNecromancerStoreOwner),
        nameof(SolostoranStoreOwner),
        nameof(AchsheTheTentacledStoreOwner),
        nameof(KazaTheNobleStoreOwner),
        nameof(FazzilTheDarkStoreOwner),
        nameof(AngelStoreOwner),
        nameof(FlotsamTheBloatedStoreOwner),
        nameof(NievalStoreOwner),
        nameof(AnastasiaTheLuminousStoreOwner),
        nameof(KeldornTheGrandStoreOwner),
        nameof(PhilanthropusStoreOwner),
        nameof(AgnarTheEnchantressStoreOwner),
        nameof(BulianceTheNecromancerStoreOwner),
        nameof(VuirakTheHighMageStoreOwner),
        nameof(MadishTheSmartStoreOwner),
        nameof(FalebrimborStoreOwner),
        nameof(FelilGandTheSubtleStoreOwner),
        nameof(ThalegordTheShamanStoreOwner),
        nameof(CthoalothTheMysticStoreOwner),
        nameof(IbeliTheIllusionistStoreOwner),
        nameof(HetoTheNecromancerStoreOwner)
    };

    public override string FeatureType => "MagicShop";
    public override ColorEnum Color => ColorEnum.Red;
    protected override string SymbolName => nameof(NumberSixSymbol);
    public override string Description => "Magic Shop";

    public override StoreStockManifest[]? StoreStockManifests => new[]
    {
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(CharismaAmuletJeweleryItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ResistAcidAmuletJeweleryItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SearchingAmuletJeweleryItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SlowDigestionAmuletJeweleryItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(CantripsforBeginnersFolkBookItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MagicksOfMasteryFolkBookItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MajorMagicksFolkBookItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MinorMagicksFolkBookItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(OrbLightSourceItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LevitationRingItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ProtectionRingItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ResistColdRingItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ResistFireRingItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BeginnersHandbookSorceryBookItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MasterSorcerersHandbookSorceryBookItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(CureLightWoundsStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(DetectEvilStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(DetectInvisibleStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(DoorStairLocationStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(EnlightenmentStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LightStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ObjectLocationStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(PerceptionStaffItemFactory)), 5),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ProbingStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RemoveCurseStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(TeleportationStaffItemFactory)), 3),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(TrapLocationStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(TreasureLocationStaffItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ConfuseMonsterWandItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(DisarmingWandItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MagicMissileWandItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SleepMonsterWandItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SlowMonsterWandItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(StinkingCloudWandItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(WonderWandItemFactory))),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for any magic book, amulets, rings, staves, wands, rods, scrolls and potions of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(SorceryBookItemFilter),
        nameof(NatureBookItemFilter),
        nameof(ChaosBookItemFilter),
        nameof(DeathBookItemFilter),
        nameof(TarotBookItemFilter),
        nameof(FolkBookItemFilter),
        nameof(CorporealBookItemFilter),
        nameof(AmuletJeweleryItemFilter),
        nameof(RingItemFilter),
        nameof(StaffItemFilter),
        nameof(WandItemFilter),
        nameof(RodItemFilter),
        nameof(ScrollItemFilter),
        nameof(PotionItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(ResearchItemStoreCommand);
}
