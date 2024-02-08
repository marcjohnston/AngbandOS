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

    protected override string[] ShopkeeperNames => new string[]
    {
        nameof(RandolphCarterShopkeeper),
        nameof(OdnarTheSageShopkeeper),
        nameof(GandarTheNeutralShopkeeper),
        nameof(RoshaThePatientShopkeeper),
        nameof(SaraiTheSwiftShopkeeper),
        nameof(BodrilTheSeerShopkeeper),
        nameof(VeloinTheQuietShopkeeper),
        nameof(VanthylasTheLearnedShopkeeper),
        nameof(OsseinTheLiterateShopkeeper),
        nameof(OlvarBookwormShopkeeper),
        nameof(ShallowgraveShopkeeper),
        nameof(DeathMaskShopkeeper),
        nameof(PorcinaTheObeseShopkeeper),
        nameof(GlarunaBrandybreathShopkeeper),
        nameof(FurfaceYeekShopkeeper),
        nameof(BaldOgginShopkeeper),
        nameof(AsuunuTheLearnedShopkeeper),
        nameof(PrirandTheDeadShopkeeper),
        nameof(RonarTheIronShopkeeper),
        nameof(GalilGamirShopkeeper),
        nameof(RorbagBookEaterShopkeeper),
        nameof(KiriarikirkShopkeeper),
        nameof(RilinTheQuietShopkeeper),
        nameof(IsungTheLordShopkeeper)
    };

    protected override string TileName => "Bookstore";

    protected override StoreStockManifestDefinition[]? StoreStockManifestDefinitions => new[]
    {
        new StoreStockManifestDefinition(nameof(MasteryChaosBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(SignOfChaosChaosBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(BasicChiFlowCorporealBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(YogicMasteryCorporealBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(BlackMassDeathBookItemFactory), 4),
        new StoreStockManifestDefinition(nameof(BlackPrayersDeathBookItemFactory), 4),
        new StoreStockManifestDefinition(nameof(CantripsforBeginnersFolkBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MagicksOfMasteryFolkBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MajorMagicksFolkBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MinorMagicksFolkBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(CommonPrayerLifeBookItemFactory), 4),
        new StoreStockManifestDefinition(nameof(HighMassLifeBookItemFactory), 4),
        new StoreStockManifestDefinition(nameof(CallOfTheWildNatureBookItemFactory), 4),
        new StoreStockManifestDefinition(nameof(NatureMasteryNatureBookItemFactory), 4),
        new StoreStockManifestDefinition(nameof(BeginnersHandbookSorceryBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MasterSorcerersHandbookSorceryBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(CardMasteryTarotBookItemFactory), 2),
        new StoreStockManifestDefinition(nameof(ConjuringsTricksTarotBookItemFactory), 2),
    };

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
