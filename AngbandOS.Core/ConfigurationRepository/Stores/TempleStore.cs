// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class TempleStore : Store
{
    private TempleStore(SaveGame saveGame) : base(saveGame) { }

    public override string FeatureType => "Temple";
    public override ColourEnum Colour => ColourEnum.Green;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(NumberFourSymbol));

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(LudwigTheHumbleStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GunnarThePaladinStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SirParsivalThePureStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AsenathTheHolyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(McKinnonStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MistressChastityStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HashnikTheDruidStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FinakStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(KrikkikStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MorivalTheWildStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HoshakTheDarkStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AtalTheWiseStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(IbeniddTheChasteStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EridishStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(VrudushTheShamanStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HaobTheBerserkerStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ProogdishTheYouthfullStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(LumwiseTheMadStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MuirtTheVirtuousStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DardobardTheWeakStoreOwner))
    };

    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(HaftedBallAndChain), 2),
            new StockStoreInventoryItem(typeof(HaftedFlail)),
            new StockStoreInventoryItem(typeof(HaftedLeadFilledMace)),
            new StockStoreInventoryItem(typeof(HaftedLucerneHammer)),
            new StockStoreInventoryItem(typeof(HaftedMace), 2),
            new StockStoreInventoryItem(typeof(HaftedMorningStar)),
            new StockStoreInventoryItem(typeof(HaftedQuarterstaff)),
            new StockStoreInventoryItem(typeof(HaftedWarHammer), 2),
            new StockStoreInventoryItem(typeof(HaftedWhip), 2),
            new StockStoreInventoryItem(typeof(CommonPrayerLifeBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(HighMassLifeBookItemFactory), 4),
            new StockStoreInventoryItem(typeof(CureCriticalWoundsPotionItemFactory), 4),
            new StockStoreInventoryItem(typeof(CureLightWoundsPotionItemFactory)),
            new StockStoreInventoryItem(typeof(CureSeriousWoundsPotionItemFactory), 2),
            new StockStoreInventoryItem(typeof(HeroismPotionItemFactory)),
            new StockStoreInventoryItem(typeof(RestoreLifeLevelsPotionItemFactory), 6),
            new StockStoreInventoryItem(typeof(ScrollBlessing)),
            new StockStoreInventoryItem(typeof(ScrollHolyChant)),
            new StockStoreInventoryItem(typeof(ScrollRemoveCurse), 3),
            new StockStoreInventoryItem(typeof(ScrollSpecialRemoveCurse), 2),
            new StockStoreInventoryItem(typeof(ScrollWordOfRecall), 6),
        };
    }

    public override bool ItemMatches(Item item)
    {
        switch (item.Factory)
        {
            case LifeBookItemFactory _:
            case ScrollItemClass _:
            case PotionItemFactory _:
            case HaftedItemClass _:
                return item.Value() > 0;
            case PolearmItemClass _:
            case SwordItemClass _:
                item.RefreshFlagBasedProperties();
                if (item.Characteristics.Blessed)
                    return item.Value() > 0;
                else
                    return false;
            default:
                return false;
        }
    }
    protected override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<RemoveCurseStoreCommand>();
    protected override StoreCommand AdvertisedStoreCommand5 => SaveGame.SingletonRepository.StoreCommands.Get<SacrificeStoreCommand>();
}
