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

    public override StoreStockManifest[]? GetStoreTable()
    {
        return new[]
        {
            new StoreStockManifest(typeof(CharismaAmuletJeweleryItemFactory)),
            new StoreStockManifest(typeof(ResistAcidAmuletJeweleryItemFactory)),
            new StoreStockManifest(typeof(SearchingAmuletJeweleryItemFactory)),
            new StoreStockManifest(typeof(SlowDigestionAmuletJeweleryItemFactory)),
            new StoreStockManifest(typeof(CantripsforBeginnersFolkBookItemFactory), 2),
            new StoreStockManifest(typeof(MagicksOfMasteryFolkBookItemFactory), 2),
            new StoreStockManifest(typeof(MajorMagicksFolkBookItemFactory), 2),
            new StoreStockManifest(typeof(MinorMagicksFolkBookItemFactory), 2),
            new StoreStockManifest(typeof(OrbLightSourceItemFactory)),
            new StoreStockManifest(typeof(LevitationRingItemFactory)),
            new StoreStockManifest(typeof(ProtectionRingItemFactory), 2),
            new StoreStockManifest(typeof(ResistColdRingItemFactory)),
            new StoreStockManifest(typeof(ResistFireRingItemFactory)),
            new StoreStockManifest(typeof(BeginnersHandbookSorceryBookItemFactory), 2),
            new StoreStockManifest(typeof(MasterSorcerersHandbookSorceryBookItemFactory), 2),
            new StoreStockManifest(typeof(CureLightWoundsStaffItemFactory)),
            new StoreStockManifest(typeof(DetectEvilStaffItemFactory)),
            new StoreStockManifest(typeof(DetectInvisibleStaffItemFactory)),
            new StoreStockManifest(typeof(DoorStairLocationStaffItemFactory)),
            new StoreStockManifest(typeof(EnlightenmentStaffItemFactory)),
            new StoreStockManifest(typeof(LightStaffItemFactory)),
            new StoreStockManifest(typeof(ObjectLocationStaffItemFactory)),
            new StoreStockManifest(typeof(PerceptionStaffItemFactory), 5),
            new StoreStockManifest(typeof(ProbingStaffItemFactory)),
            new StoreStockManifest(typeof(RemoveCurseStaffItemFactory)),
            new StoreStockManifest(typeof(TeleportationStaffItemFactory), 3),
            new StoreStockManifest(typeof(TrapLocationStaffItemFactory)),
            new StoreStockManifest(typeof(TreasureLocationStaffItemFactory)),
            new StoreStockManifest(typeof(ConfuseMonsterWandItemFactory)),
            new StoreStockManifest(typeof(DisarmingWandItemFactory)),
            new StoreStockManifest(typeof(MagicMissileWandItemFactory)),
            new StoreStockManifest(typeof(SleepMonsterWandItemFactory)),
            new StoreStockManifest(typeof(SlowMonsterWandItemFactory)),
            new StoreStockManifest(typeof(StinkingCloudWandItemFactory)),
            new StoreStockManifest(typeof(WonderWandItemFactory)),
        };
    }

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
