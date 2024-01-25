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
    public override ColourEnum Colour => ColourEnum.Red;
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
            new StockStoreInventoryItem(typeof(StaffCureLightWounds)),
            new StockStoreInventoryItem(typeof(StaffDetectEvil)),
            new StockStoreInventoryItem(typeof(StaffDetectInvisible)),
            new StockStoreInventoryItem(typeof(StaffDoorStairLocation)),
            new StockStoreInventoryItem(typeof(StaffEnlightenment)),
            new StockStoreInventoryItem(typeof(StaffLight)),
            new StockStoreInventoryItem(typeof(StaffObjectLocation)),
            new StockStoreInventoryItem(typeof(StaffPerception), 5),
            new StockStoreInventoryItem(typeof(StaffProbing)),
            new StockStoreInventoryItem(typeof(StaffRemoveCurse)),
            new StockStoreInventoryItem(typeof(StaffTeleportation), 3),
            new StockStoreInventoryItem(typeof(StaffTrapLocation)),
            new StockStoreInventoryItem(typeof(StaffTreasureLocation)),
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
        nameof(SorceryBookItemMatchingCriteria),
        nameof(NatureBookItemMatchingCriteria),
        nameof(ChaosBookItemMatchingCriteria),
        nameof(DeathBookItemMatchingCriteria),
        nameof(TarotBookItemMatchingCriteria),
        nameof(FolkBookItemMatchingCriteria),
        nameof(CorporealBookItemMatchingCriteria),
        nameof(AmuletJeweleryItemMatchingCriteria),
        nameof(RingItemMatchingCriteria),
        nameof(StaffItemMatchingCriteria),
        nameof(WandItemMatchingCriteria),
        nameof(RodItemMatchingCriteria),
        nameof(ScrollItemMatchingCriteria),
        nameof(PotionItemMatchingCriteria)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(ResearchItemStoreCommand);
}
