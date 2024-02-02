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

    public override StoreStockManifest[]? StoreStockManifests => new[]
    {
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(WoodenArrowAmmunitionItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SteelBoltAmmunitionItemFactory)), 4),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LightCrossbowBowWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LongBowWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ShortBowWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SlingBowWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(WhipHaftedWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(AwlPikePolearmWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BattleAxePolearmWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BeakedAxePolearmWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BroadAxePolearmWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LancePolearmWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(PikePolearmWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SpearPolearmWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(TridentPolearmWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(IronShotAmmunitionItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BastardSwordSwordWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(BroadSwordWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(CutlassWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(DaggerWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(KatanaWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(LongSwordWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(MainGaucheWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(RapierWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SabreWeaponItemFactory))),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ScimitarWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(ShortSwordWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(SmallSwordWeaponItemFactory)), 2),
        new StoreStockManifest(SaveGame.SingletonRepository.ItemFactories.Get(nameof(TulwarWeaponItemFactory))),
    };

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
