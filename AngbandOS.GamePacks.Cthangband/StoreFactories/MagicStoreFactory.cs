// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MagicStoreFactory : StoreFactoryGameConfiguration
{

    public override string[] ShopkeeperNames => new string[]
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

    public override string TileName => nameof(MagicStoreTile);

    public override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(CharismaAmuletItemFactory), 1),
        (nameof(ResistAcidAmuletItemFactory), 1),
        (nameof(SearchingAmuletItemFactory), 1),
        (nameof(SlowDigestionAmuletItemFactory), 1),
        (nameof(CantripsForBeginnersFolkBookItemFactory), 2),
        (nameof(MagicksOfMasteryFolkBookItemFactory), 2),
        (nameof(MajorMagicksFolkBookItemFactory), 2),
        (nameof(MinorMagicksFolkBookItemFactory), 2),
        (nameof(OrbLightSourceItemFactory), 1),
        (nameof(LevitationRingItemFactory), 1),
        (nameof(ProtectionRingItemFactory), 2),
        (nameof(ResistColdRingItemFactory), 1),
        (nameof(ResistFireRingItemFactory), 1),
        (nameof(BeginnersHandbookSorceryBookItemFactory), 2),
        (nameof(MasterSorcerersHandbookSorceryBookItemFactory), 2),
        (nameof(CureLightWoundsStaffItemFactory), 1),
        (nameof(DetectEvilStaffItemFactory), 1),
        (nameof(DetectInvisibleStaffItemFactory), 1),
        (nameof(DoorStairLocationStaffItemFactory), 1),
        (nameof(EnlightenmentStaffItemFactory), 1),
        (nameof(LightStaffItemFactory), 1),
        (nameof(ObjectLocationStaffItemFactory), 1),
        (nameof(PerceptionStaffItemFactory), 5),
        (nameof(ProbingStaffItemFactory), 1),
        (nameof(RemoveCurseStaffItemFactory), 1),
        (nameof(TeleportationStaffItemFactory), 3),
        (nameof(TrapLocationStaffItemFactory), 1),
        (nameof(TreasureLocationStaffItemFactory), 1),
        (nameof(ConfuseMonsterWandItemFactory), 1),
        (nameof(DisarmingWandItemFactory), 1),
        (nameof(MagicMissileWandItemFactory), 1),
        (nameof(SleepMonsterWandItemFactory), 1),
        (nameof(SlowMonsterWandItemFactory), 1),
        (nameof(StinkingCloudWandItemFactory), 1),
        (nameof(WonderWandItemFactory), 1),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for any magic book, amulets, rings, staves, wands, rods, scrolls and potions of value.
    /// </summary>
    public override string[] ItemFilterNames => new string[]
    {
        nameof(ItemFiltersEnum.SorcerySpellBooksOfValueItemFilter),
        nameof(ItemFiltersEnum.NatureSpellBooksOfValueItemFilter),
        nameof(ItemFiltersEnum.ChaosSpellBooksOfValueItemFilter),
        nameof(ItemFiltersEnum.DeathSpellBooksOfValueItemFilter),
        nameof(ItemFiltersEnum.TarotSpellBooksOfValueItemFilter),
        nameof(ItemFiltersEnum.FolkSpellBooksOfValueItemFilter),
        nameof(ItemFiltersEnum.CorporealSpellBooksOfValueItemFilter),
        nameof(ItemFiltersEnum.AmuletsOfValueItemFilter),
        nameof(ItemFiltersEnum.RingsOfValueItemFilter),
        nameof(ItemFiltersEnum.StaffsOfValueItemFilter),
        nameof(ItemFiltersEnum.WandsOfValueItemFilter),
        nameof(ItemFiltersEnum.RodsOfValueItemFilter),
        nameof(ItemFiltersEnum.ScrollsOfValueItemFilter),
        nameof(ItemFiltersEnum.PotionsOfValueItemFilter)
    };

    public override string? AdvertisedStoreCommand4Name => nameof(ResearchItemStoreCommand);
}
