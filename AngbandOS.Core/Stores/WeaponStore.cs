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
    public WeaponStore(SaveGame saveGame) : base(saveGame) { }

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<ArnoldTheBeastlyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ArndalBeastSlayerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<EdorTheShortStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<OglignDragonSlayerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DrewTheSkilledStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<OrraxDragonsonStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BobStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ArkhothTheStoutStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SarlyasTheRottenStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<TuethicBareBonesStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BiliousTheToadStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FasgulStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<EllefrisThePaladinStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<KtrrikkStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DrocusSpiderfriendStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FungusGiantSlayerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<NadocTheStrongStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<EramogTheWeakStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<EowilithTheFairStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HuimogBalrogSlayerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<PeadusTheCruelStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<VamogSlayerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HooshnakTheViciousStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BalennWarDancerStoreOwner>()
    };

    public override string FeatureType => "Weaponsmiths";
    public override Colour Colour => Colour.White;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<NumberThreeSymbol>();

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
    protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<EnchantWeaponStoreCommand>();
}
