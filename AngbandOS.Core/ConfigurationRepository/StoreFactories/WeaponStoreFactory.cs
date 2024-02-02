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

    public override StoreStockManifest[]? GetStoreTable()
    {
        return new[]
        {
            new StoreStockManifest(typeof(WoodenArrowAmmunitionItemFactory), 4),
            new StoreStockManifest(typeof(SteelBoltAmmunitionItemFactory), 4),
            new StoreStockManifest(typeof(LightCrossbowBowWeaponItemFactory), 2),
            new StoreStockManifest(typeof(LongBowWeaponItemFactory), 2),
            new StoreStockManifest(typeof(ShortBowWeaponItemFactory), 2),
            new StoreStockManifest(typeof(SlingBowWeaponItemFactory)),
            new StoreStockManifest(typeof(WhipHaftedWeaponItemFactory), 2),
            new StoreStockManifest(typeof(AwlPikePolearmWeaponItemFactory)),
            new StoreStockManifest(typeof(BattleAxePolearmWeaponItemFactory)),
            new StoreStockManifest(typeof(BeakedAxePolearmWeaponItemFactory)),
            new StoreStockManifest(typeof(BroadAxePolearmWeaponItemFactory)),
            new StoreStockManifest(typeof(LancePolearmWeaponItemFactory)),
            new StoreStockManifest(typeof(PikePolearmWeaponItemFactory)),
            new StoreStockManifest(typeof(SpearPolearmWeaponItemFactory)),
            new StoreStockManifest(typeof(TridentPolearmWeaponItemFactory)),
            new StoreStockManifest(typeof(IronShotAmmunitionItemFactory), 2),
            new StoreStockManifest(typeof(BastardSwordSwordWeaponItemFactory)),
            new StoreStockManifest(typeof(BroadSwordWeaponItemFactory), 2),
            new StoreStockManifest(typeof(CutlassWeaponItemFactory)),
            new StoreStockManifest(typeof(DaggerWeaponItemFactory), 2),
            new StoreStockManifest(typeof(KatanaWeaponItemFactory)),
            new StoreStockManifest(typeof(LongSwordWeaponItemFactory), 2),
            new StoreStockManifest(typeof(MainGaucheWeaponItemFactory), 2),
            new StoreStockManifest(typeof(RapierWeaponItemFactory), 2),
            new StoreStockManifest(typeof(SabreWeaponItemFactory)),
            new StoreStockManifest(typeof(ScimitarWeaponItemFactory), 2),
            new StoreStockManifest(typeof(ShortSwordWeaponItemFactory), 2),
            new StoreStockManifest(typeof(SmallSwordWeaponItemFactory), 2),
            new StoreStockManifest(typeof(TulwarWeaponItemFactory)),
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
