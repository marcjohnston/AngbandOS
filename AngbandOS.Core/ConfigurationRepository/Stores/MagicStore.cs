﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class MagicStore : Store
{
    private MagicStore(SaveGame saveGame) : base(saveGame) { }

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<SkidneyTheSorcererStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BuggerbyTheGreatStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<KyriaTheIllusionistStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<NikkiTheNecromancerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SolostoranStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AchsheTheTentacledStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<KazaTheNobleStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FazzilTheDarkStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AngelStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FlotsamTheBloatedStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<NievalStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AnastasiaTheLuminousStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<KeldornTheGrandStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<PhilanthropusStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AgnarTheEnchantressStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BulianceTheNecromancerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<VuirakTheHighMageStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<MadishTheSmartStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FalebrimborStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FelilGandTheSubtleStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ThalegordTheShamanStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<CthoalothTheMysticStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<IbeliTheIllusionistStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HetoTheNecromancerStoreOwner>()
    };

    public override string FeatureType => "MagicShop";
    public override ColourEnum Colour => ColourEnum.Red;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<NumberSixSymbol>();
    public override string Description => "Magic Shop";

    protected override StockStoreInventoryItem[] GetStoreTable()
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

    public override bool ItemMatches(Item item)
    {
        switch (item.Factory)
        {
            case SorceryBookItemFactory _:
            case NatureBookItemFactory _:
            case ChaosBookItemFactory _:
            case DeathBookItemFactory _:
            case TarotBookItemFactory _:
            case FolkBookItemFactory _:
            case CorporealBookItemFactory _:
            case AmuletJeweleryItemFactory _:
            case RingItemFactory _:
            case StaffItemClass _:
            case WandItemFactory _:
            case RodItemFactory _:
            case ScrollItemClass _:
            case PotionItemFactory _:
                return item.Value() > 0;
            default:
                return false;
        }
    }
    protected override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<ResearchItemStoreCommand>();
}