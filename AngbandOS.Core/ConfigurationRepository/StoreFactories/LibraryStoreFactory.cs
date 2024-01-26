// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class LibraryStoreFactory : StoreFactory
{
    private LibraryStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(RandolphCarterStoreOwner),
        nameof(OdnarTheSageStoreOwner),
        nameof(GandarTheNeutralStoreOwner),
        nameof(RoshaThePatientStoreOwner),
        nameof(SaraiTheSwiftStoreOwner),
        nameof(BodrilTheSeerStoreOwner),
        nameof(VeloinTheQuietStoreOwner),
        nameof(VanthylasTheLearnedStoreOwner),
        nameof(OsseinTheLiterateStoreOwner),
        nameof(OlvarBookwormStoreOwner),
        nameof(ShallowgraveStoreOwner),
        nameof(DeathMaskStoreOwner),
        nameof(PorcinaTheObeseStoreOwner),
        nameof(GlarunaBrandybreathStoreOwner),
        nameof(FurfaceYeekStoreOwner),
        nameof(BaldOgginStoreOwner),
        nameof(AsuunuTheLearnedStoreOwner),
        nameof(PrirandTheDeadStoreOwner),
        nameof(RonarTheIronStoreOwner),
        nameof(GalilGamirStoreOwner),
        nameof(RorbagBookEaterStoreOwner),
        nameof(KiriarikirkStoreOwner),
        nameof(RilinTheQuietStoreOwner),
        nameof(IsungTheLordStoreOwner)
    };

    public override string FeatureType => "Bookstore";
    public override ColorEnum Color => ColorEnum.Orange;
    protected override string SymbolName => nameof(NumberNineSymbol);

    public override StockStoreInventoryItem[]? GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(MasteryChaosBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(SignOfChaosChaosBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(BasicChiFlowCorporealBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(YogicMasteryCorporealBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(BlackMassDeathBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(BlackPrayersDeathBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(CantripsforBeginnersFolkBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(MagicksOfMasteryFolkBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(MajorMagicksFolkBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(MinorMagicksFolkBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(CommonPrayerLifeBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(HighMassLifeBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(CallOfTheWildNatureBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(NatureMasteryNatureBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(BeginnersHandbookSorceryBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(MasterSorcerersHandbookSorceryBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(CardMasteryTarotBookItemFactory), 2),
            new StockStoreInventoryItem(typeof(ConjuringsTricksTarotBookItemFactory), 2),
        };
    }

    /// <summary>
    /// Returns the name of the item matching criteria for any book of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(SorceryBookItemFilter),
        nameof(LifeBookItemFilter),
        nameof(NatureBookItemFilter),
        nameof(ChaosBookItemFilter),
        nameof(DeathBookItemFilter),
        nameof(TarotBookItemFilter),
        nameof(FolkBookItemFilter),
        nameof(CorporealBookItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(ResearchSpellStoreCommand);
}
