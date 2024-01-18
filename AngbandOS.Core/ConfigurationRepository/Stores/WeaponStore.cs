// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class WeaponStore : Store
{
    private WeaponStore(SaveGame saveGame) : base(saveGame) { }

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ArnoldTheBeastlyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ArndalBeastSlayerStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EdorTheShortStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(OglignDragonSlayerStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DrewTheSkilledStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(OrraxDragonsonStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(BobStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ArkhothTheStoutStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SarlyasTheRottenStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(TuethicBareBonesStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(BiliousTheToadStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FasgulStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EllefrisThePaladinStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(KtrrikkStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DrocusSpiderfriendStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FungusGiantSlayerStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(NadocTheStrongStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EramogTheWeakStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EowilithTheFairStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HuimogBalrogSlayerStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(PeadusTheCruelStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(VamogSlayerStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HooshnakTheViciousStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(BalennWarDancerStoreOwner))
    };

    public override string FeatureType => "Weaponsmiths";
    public override ColourEnum Colour => ColourEnum.White;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(NumberThreeSymbol));

    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(WoodenArrowAmmunitionItemFactory), 4),
            new StockStoreInventoryItem(typeof(SteelBoltAmmunitionItemFactory), 4),
            new StockStoreInventoryItem(typeof(LightCrossbowBowWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(LongBowWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(ShortBowWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(SlingBowWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(HaftedWhip), 2),
            new StockStoreInventoryItem(typeof(PolearmAwlPike)),
            new StockStoreInventoryItem(typeof(PolearmBattleAxe)),
            new StockStoreInventoryItem(typeof(PolearmBeakedAxe)),
            new StockStoreInventoryItem(typeof(PolearmBroadAxe)),
            new StockStoreInventoryItem(typeof(PolearmLance)),
            new StockStoreInventoryItem(typeof(PolearmPike)),
            new StockStoreInventoryItem(typeof(PolearmSpear)),
            new StockStoreInventoryItem(typeof(PolearmTrident)),
            new StockStoreInventoryItem(typeof(IronShotAmmunitionItemFactory), 2),
            new StockStoreInventoryItem(typeof(SwordBastardSword)),
            new StockStoreInventoryItem(typeof(SwordBroadSword), 2),
            new StockStoreInventoryItem(typeof(SwordCutlass)),
            new StockStoreInventoryItem(typeof(SwordDagger), 2),
            new StockStoreInventoryItem(typeof(SwordKatana)),
            new StockStoreInventoryItem(typeof(SwordLongSword), 2),
            new StockStoreInventoryItem(typeof(SwordMainGauche), 2),
            new StockStoreInventoryItem(typeof(SwordRapier), 2),
            new StockStoreInventoryItem(typeof(SwordSabre)),
            new StockStoreInventoryItem(typeof(SwordScimitar), 2),
            new StockStoreInventoryItem(typeof(SwordShortSword), 2),
            new StockStoreInventoryItem(typeof(SwordSmallSword), 2),
            new StockStoreInventoryItem(typeof(SwordTulwar)),
        };
    }

    public override bool ItemMatches(Item item)
    {
        switch (item.Factory)
        {
            case ShotAmmunitionItemFactory _:
            case BoltAmmunitionItemFactory _:
            case ArrowAmmunitionItemFactory _:
            case BowWeaponItemFactory _:
            case DiggingItemClass _:
            case HaftedItemClass _:
            case PolearmItemClass _:
            case SwordItemClass _:
                return item.Value() > 0;
            default:
                return false;
        }
    }
    protected override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(EnchantWeaponStoreCommand));
}
