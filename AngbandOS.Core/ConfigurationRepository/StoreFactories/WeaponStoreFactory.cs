// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal partial class WeaponStoreFactory : StoreFactory
{
    private WeaponStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(ArnoldTheBeastlyStoreOwner),
        nameof(ArndalBeastSlayerStoreOwner),
        nameof(EdorTheShortStoreOwner),
        nameof(OglignDragonSlayerStoreOwner),
        nameof(DrewTheSkilledStoreOwner),
        nameof(OrraxDragonsonStoreOwner),
        nameof(BobStoreOwner),
        nameof(ArkhothTheStoutStoreOwner),
        nameof(SarlyasTheRottenStoreOwner),
        nameof(TuethicBareBonesStoreOwner),
        nameof(BiliousTheToadStoreOwner),
        nameof(FasgulStoreOwner),
        nameof(EllefrisThePaladinStoreOwner),
        nameof(KtrrikkStoreOwner),
        nameof(DrocusSpiderfriendStoreOwner),
        nameof(FungusGiantSlayerStoreOwner),
        nameof(NadocTheStrongStoreOwner),
        nameof(EramogTheWeakStoreOwner),
        nameof(EowilithTheFairStoreOwner),
        nameof(HuimogBalrogSlayerStoreOwner),
        nameof(PeadusTheCruelStoreOwner),
        nameof(VamogSlayerStoreOwner),
        nameof(HooshnakTheViciousStoreOwner),
        nameof(BalennWarDancerStoreOwner)
    };

    public override string FeatureType => "Weaponsmiths";
    public override ColorEnum Color => ColorEnum.White;
    protected override string SymbolName => nameof(NumberThreeSymbol);

    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(WoodenArrowAmmunitionItemFactory), 4),
            new StockStoreInventoryItem(typeof(SteelBoltAmmunitionItemFactory), 4),
            new StockStoreInventoryItem(typeof(LightCrossbowBowWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(LongBowWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(ShortBowWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(SlingBowWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(WhipHaftedWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(AwlPikePolearmWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(BattleAxePolearmWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(BeakedAxePolearmWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(BroadAxePolearmWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(LancePolearmWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(PikePolearmWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(SpearPolearmWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(TridentPolearmWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(IronShotAmmunitionItemFactory), 2),
            new StockStoreInventoryItem(typeof(BastardSwordSwordWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(BroadSwordWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(CutlassWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(DaggerWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(KatanaWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(LongSwordWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(MainGaucheWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(RapierWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(SabreWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(ScimitarWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(ShortSwordWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(SmallSwordWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(TulwarWeaponItemFactory)),
        };
    }

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(ShotAmmunitionItemFilter),
        nameof(BoltAmmunitionItemFilter),
        nameof(ArrowAmmunitionItemFilter),
        nameof(BowWeaponItemFilter),
        nameof(DiggingItemFilter),
        nameof(HaftedItemFilter),
        nameof(PolearmItemFilter),
        nameof(SwordItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(EnchantWeaponStoreCommand);
}
