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

    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(CharismaAmuletJeweleryItemFactory)),
            new StockStoreInventoryItem(typeof(ResistAcidAmuletJeweleryItemFactory)),
            new StockStoreInventoryItem(typeof(SearchingAmuletJeweleryItemFactory)),
            new StockStoreInventoryItem(typeof(SlowDigestionAmuletJeweleryItemFactory)),
            new StockStoreInventoryItem(typeof(CantripsforBeginnersFolkBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(MagicksOfMasteryFolkBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(MajorMagicksFolkBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(MinorMagicksFolkBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(OrbLightSourceItemFactory)),
            new StockStoreInventoryItem(typeof(LevitationRingItemFactory)),
            new StockStoreInventoryItem(typeof(ProtectionRingItemFactory), 2),
            new StockStoreInventoryItem(typeof(ResistColdRingItemFactory)),
            new StockStoreInventoryItem(typeof(ResistFireRingItemFactory)),
            new StockStoreInventoryItem(typeof(BeginnersHandbookSorceryBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(MasterSorcerersHandbookSorceryBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(CureLightWoundsStaffItemFactory)),
            new StockStoreInventoryItem(typeof(DetectEvilStaffItemFactory)),
            new StockStoreInventoryItem(typeof(DetectInvisibleStaffItemFactory)),
            new StockStoreInventoryItem(typeof(DoorStairLocationStaffItemFactory)),
            new StockStoreInventoryItem(typeof(EnlightenmentStaffItemFactory)),
            new StockStoreInventoryItem(typeof(LightStaffItemFactory)),
            new StockStoreInventoryItem(typeof(ObjectLocationStaffItemFactory)),
            new StockStoreInventoryItem(typeof(PerceptionStaffItemFactory), 5),
            new StockStoreInventoryItem(typeof(ProbingStaffItemFactory)),
            new StockStoreInventoryItem(typeof(RemoveCurseStaffItemFactory)),
            new StockStoreInventoryItem(typeof(TeleportationStaffItemFactory), 3),
            new StockStoreInventoryItem(typeof(TrapLocationStaffItemFactory)),
            new StockStoreInventoryItem(typeof(TreasureLocationStaffItemFactory)),
            new StockStoreInventoryItem(typeof(ConfuseMonsterWandItemFactory)),
            new StockStoreInventoryItem(typeof(DisarmingWandItemFactory)),
            new StockStoreInventoryItem(typeof(MagicMissileWandItemFactory)),
            new StockStoreInventoryItem(typeof(SleepMonsterWandItemFactory)),
            new StockStoreInventoryItem(typeof(SlowMonsterWandItemFactory)),
            new StockStoreInventoryItem(typeof(StinkingCloudWandItemFactory)),
            new StockStoreInventoryItem(typeof(WonderWandItemFactory)),
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
