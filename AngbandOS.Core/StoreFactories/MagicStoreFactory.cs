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
    private MagicStoreFactory(Game game) : base(game) { }

    protected override string[] ShopkeeperNames => new string[]
    {
        nameof(SkidneyTheSorcererShopkeeper),
        nameof(BuggerbyTheGreatShopkeeper),
        nameof(KyriaTheIllusionistShopkeeper),
        nameof(NikkiTheNecromancerShopkeeper),
        nameof(SolostoranShopkeeper),
        nameof(AchsheTheTentacledShopkeeper),
        nameof(KazaTheNobleShopkeeper),
        nameof(FazzilTheDarkShopkeeper),
        nameof(AngelShopkeeper),
        nameof(FlotsamTheBloatedShopkeeper),
        nameof(NievalShopkeeper),
        nameof(AnastasiaTheLuminousShopkeeper),
        nameof(KeldornTheGrandShopkeeper),
        nameof(PhilanthropusShopkeeper),
        nameof(AgnarTheEnchantressShopkeeper),
        nameof(BulianceTheNecromancerShopkeeper),
        nameof(VuirakTheHighMageShopkeeper),
        nameof(MadishTheSmartShopkeeper),
        nameof(FalebrimborShopkeeper),
        nameof(FelilGandTheSubtleShopkeeper),
        nameof(ThalegordTheShamanShopkeeper),
        nameof(CthoalothTheMysticShopkeeper),
        nameof(IbeliTheIllusionistShopkeeper),
        nameof(HetoTheNecromancerShopkeeper)
    };

    protected override string TileName => nameof(MagicStoreTile);

    protected override StoreStockManifestDefinition[]? StoreStockManifestDefinitions => new[]
    {
        new StoreStockManifestDefinition(nameof(CharismaAmuletJeweleryItemFactory)),
        new StoreStockManifestDefinition(nameof(ResistAcidAmuletJeweleryItemFactory)),
        new StoreStockManifestDefinition(nameof(SearchingAmuletJeweleryItemFactory)),
        new StoreStockManifestDefinition(nameof(SlowDigestionAmuletJeweleryItemFactory)),
        new StoreStockManifestDefinition(nameof(CantripsforBeginnersFolkBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MagicksOfMasteryFolkBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MajorMagicksFolkBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MinorMagicksFolkBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(OrbLightSourceItemFactory)),
        new StoreStockManifestDefinition(nameof(LevitationRingItemFactory)),
        new StoreStockManifestDefinition(nameof(ProtectionRingItemFactory), 2),
        new StoreStockManifestDefinition(nameof(ResistColdRingItemFactory)),
        new StoreStockManifestDefinition(nameof(ResistFireRingItemFactory)),
        new StoreStockManifestDefinition(nameof(BeginnersHandbookSorceryBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MasterSorcerersHandbookSorceryBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(CureLightWoundsStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(DetectEvilStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(DetectInvisibleStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(DoorStairLocationStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(EnlightenmentStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(LightStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(ObjectLocationStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(PerceptionStaffItemFactory), 5),
        new StoreStockManifestDefinition(nameof(ProbingStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(RemoveCurseStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(TeleportationStaffItemFactory), 3),
        new StoreStockManifestDefinition(nameof(TrapLocationStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(TreasureLocationStaffItemFactory)),
        new StoreStockManifestDefinition(nameof(ConfuseMonsterWandItemFactory)),
        new StoreStockManifestDefinition(nameof(DisarmingWandItemFactory)),
        new StoreStockManifestDefinition(nameof(MagicMissileWandItemFactory)),
        new StoreStockManifestDefinition(nameof(SleepMonsterWandItemFactory)),
        new StoreStockManifestDefinition(nameof(SlowMonsterWandItemFactory)),
        new StoreStockManifestDefinition(nameof(StinkingCloudWandItemFactory)),
        new StoreStockManifestDefinition(nameof(WonderWandItemFactory)),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for any magic book, amulets, rings, staves, wands, rods, scrolls and potions of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(SorcerySpellBooksOfValueItemFilter),
        nameof(NatureSpellBooksOfValueItemFilter),
        nameof(ChaosSpellBooksOfValueItemFilter),
        nameof(DeathSpellBooksOfValueItemFilter),
        nameof(TarotSpellBooksOfValueItemFilter),
        nameof(FolkSpellBooksOfValueItemFilter),
        nameof(CorporealSpellBooksOfValueItemFilter),
        nameof(AmuletsOfValueItemFilter),
        nameof(RingsOfValueItemFilter),
        nameof(StaffsOfValueItemFilter),
        nameof(WandsOfValueItemFilter),
        nameof(RodsOfValueItemFilter),
        nameof(ScrollsOfValueItemFilter),
        nameof(PotionsOfValueItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(ResearchItemStoreCommand);
}
