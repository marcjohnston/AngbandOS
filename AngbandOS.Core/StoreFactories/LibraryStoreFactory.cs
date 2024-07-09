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
    private LibraryStoreFactory(Game game) : base(game) { }

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

    protected override string TileName => nameof(LibraryStoreTile);

    protected override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(MasteryChaosBookItemFactory), 2),
        (nameof(SignOfChaosChaosBookItemFactory), 2),
        (nameof(BasicChiFlowCorporealBookItemFactory), 2),
        (nameof(YogicMasteryCorporealBookItemFactory), 2),
        (nameof(BlackMassDeathBookItemFactory), 4),
        (nameof(BlackPrayersDeathBookItemFactory), 4),
        (nameof(CantripsforBeginnersFolkBookItemFactory), 2),
        (nameof(MagicksOfMasteryFolkBookItemFactory), 2),
        (nameof(MajorMagicksFolkBookItemFactory), 2),
        (nameof(MinorMagicksFolkBookItemFactory), 2),
        (nameof(CommonPrayerLifeBookItemFactory), 4),
        (nameof(HighMassLifeBookItemFactory), 4),
        (nameof(CallOfTheWildNatureBookItemFactory), 4),
        (nameof(NatureMasteryNatureBookItemFactory), 4),
        (nameof(BeginnersHandbookSorceryBookItemFactory), 2),
        (nameof(MasterSorcerersHandbookSorceryBookItemFactory), 2),
        (nameof(CardMasteryTarotBookItemFactory), 2),
        (nameof(ConjuringsTricksTarotBookItemFactory), 2),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for any book of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(SorcerySpellBooksOfValueItemFilter),
        nameof(LifeBooksOfValueItemFilter),
        nameof(NatureSpellBooksOfValueItemFilter),
        nameof(ChaosSpellBooksOfValueItemFilter),
        nameof(DeathSpellBooksOfValueItemFilter),
        nameof(TarotSpellBooksOfValueItemFilter),
        nameof(FolkSpellBooksOfValueItemFilter),
        nameof(CorporealSpellBooksOfValueItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(ResearchSpellStoreCommand);
}
