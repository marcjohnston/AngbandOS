// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class LibraryStore : Store
{
    private LibraryStore(SaveGame saveGame) : base(saveGame) { }

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(RandolphCarterStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(OdnarTheSageStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GandarTheNeutralStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(RoshaThePatientStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SaraiTheSwiftStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(BodrilTheSeerStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(VeloinTheQuietStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(VanthylasTheLearnedStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(OsseinTheLiterateStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(OlvarBookwormStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ShallowgraveStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DeathMaskStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(PorcinaTheObeseStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GlarunaBrandybreathStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FurfaceYeekStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(BaldOgginStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AsuunuTheLearnedStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(PrirandTheDeadStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(RonarTheIronStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GalilGamirStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(RorbagBookEaterStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(KiriarikirkStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(RilinTheQuietStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(IsungTheLordStoreOwner))
    };

    public override string FeatureType => "Bookstore";
    public override ColourEnum Colour => ColourEnum.Orange;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<NumberNineSymbol>();

    protected override StockStoreInventoryItem[] GetStoreTable()
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

    public override bool ItemMatches(Item item)
    {
        switch (item.Factory)
        {
            case SorceryBookItemFactory _:
            case NatureBookItemFactory _:
            case ChaosBookItemFactory _:
            case DeathBookItemFactory _:
            case LifeBookItemFactory _:
            case TarotBookItemFactory _:
            case FolkBookItemFactory _:
            case CorporealBookItemFactory _:
                return item.Value() > 0;
            default:
                return false;
        }
    }
    protected override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<ResearchSpellStoreCommand>();
}
