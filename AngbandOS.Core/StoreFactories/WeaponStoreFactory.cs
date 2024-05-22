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
    private WeaponStoreFactory(Game game) : base(game) { }

    protected override string[] ShopkeeperNames => new string[]
    {
        nameof(ArnoldTheBeastlyShopkeeper),
        nameof(ArndalBeastSlayerShopkeeper),
        nameof(EdorTheShortShopkeeper),
        nameof(OglignDragonSlayerShopkeeper),
        nameof(DrewTheSkilledShopkeeper),
        nameof(OrraxDragonsonShopkeeper),
        nameof(BobShopkeeper),
        nameof(ArkhothTheStoutShopkeeper),
        nameof(SarlyasTheRottenShopkeeper),
        nameof(TuethicBareBonesShopkeeper),
        nameof(BiliousTheToadShopkeeper),
        nameof(FasgulShopkeeper),
        nameof(EllefrisThePaladinShopkeeper),
        nameof(KtrrikkShopkeeper),
        nameof(DrocusSpiderfriendShopkeeper),
        nameof(FungusGiantSlayerShopkeeper),
        nameof(NadocTheStrongShopkeeper),
        nameof(EramogTheWeakShopkeeper),
        nameof(EowilithTheFairShopkeeper),
        nameof(HuimogBalrogSlayerShopkeeper),
        nameof(PeadusTheCruelShopkeeper),
        nameof(VamogSlayerShopkeeper),
        nameof(HooshnakTheViciousShopkeeper),
        nameof(BalennWarDancerShopkeeper)
    };

    protected override string TileName => nameof(WeaponsmithStoreTile);

    protected override StoreStockManifestDefinition[]? StoreStockManifestDefinitions => new[]
    {
        new StoreStockManifestDefinition(nameof(WoodenArrowAmmunitionItemFactory), 4),
        new StoreStockManifestDefinition(nameof(SteelBoltAmmunitionItemFactory), 4),
        new StoreStockManifestDefinition(nameof(LightCrossbowBowWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(LongBowWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(ShortBowWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(SlingBowWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(WhipHaftedWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(AwlPikePolearmWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(BattleAxePolearmWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(BeakedAxePolearmWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(BroadAxePolearmWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(LancePolearmWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(PikePolearmWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(SpearPolearmWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(TridentPolearmWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(IronShotAmmunitionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(BastardSwordSwordWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(BroadSwordWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(CutlassWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(DaggerWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(KatanaWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(LongSwordWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(MainGaucheWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(RapierWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(SabreWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(ScimitarWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(ShortSwordWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(SmallSwordWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(TulwarWeaponItemFactory)),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(ShotsOfValueItemFilter),
        nameof(BoltsOfValueItemFilter),
        nameof(ArrowsOfValueItemFilter),
        nameof(BowsOfValueItemFilter),
        nameof(DiggersOfValueItemFilter),
        nameof(HaftedWeaponsOfValueItemFilter),
        nameof(PolearmsOfValueItemFilter),
        nameof(SwordsOfValueItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(EnchantWeaponStoreCommand);
}
