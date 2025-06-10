// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponStoreFactory : StoreFactoryGameConfiguration
{

    public override string[] ShopkeeperNames => new string[]
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

    public override string TileName => nameof(WeaponsmithStoreTile);

    public override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(WoodenArrowAmmunitionItemFactory), 4),
        (nameof(SteelBoltAmmunitionItemFactory), 4),
        (nameof(LightCrossbowRangedWeaponItemFactory), 2),
        (nameof(LongBowRangedWeaponItemFactory), 2),
        (nameof(ShortBowRangedWeaponItemFactory), 2),
        (nameof(SlingRangedWeaponItemFactory), 1),
        (nameof(WhipHaftedWeaponItemFactory), 2),
        (nameof(AwlPikePolearmWeaponItemFactory), 1),
        (nameof(BattleAxePolearmWeaponItemFactory), 1),
        (nameof(BeakedAxePolearmWeaponItemFactory), 1),
        (nameof(BroadAxePolearmWeaponItemFactory), 1),
        (nameof(LancePolearmWeaponItemFactory), 1),
        (nameof(PikePolearmWeaponItemFactory), 1),
        (nameof(SpearPolearmWeaponItemFactory), 1),
        (nameof(TridentPolearmWeaponItemFactory), 1),
        (nameof(IronShotAmmunitionItemFactory), 2),
        (nameof(BastardSwordSwordWeaponItemFactory), 1),
        (nameof(BroadSwordWeaponItemFactory), 2),
        (nameof(CutlassWeaponItemFactory), 1),
        (nameof(DaggerWeaponItemFactory), 2),
        (nameof(KatanaWeaponItemFactory), 1),
        (nameof(LongSwordWeaponItemFactory), 2),
        (nameof(MainGaucheWeaponItemFactory), 2),
        (nameof(RapierWeaponItemFactory), 2),
        (nameof(SabreWeaponItemFactory), 1),
        (nameof(ScimitarWeaponItemFactory), 2),
        (nameof(ShortSwordWeaponItemFactory), 2),
        (nameof(SmallSwordWeaponItemFactory), 2),
        (nameof(TulwarWeaponItemFactory), 1),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    public override string[] ItemFilterNames => new string[]
    {
        nameof(ItemFiltersEnum.ShotsOfValueItemFilter),
        nameof(ItemFiltersEnum.BoltsOfValueItemFilter),
        nameof(ItemFiltersEnum.ArrowsOfValueItemFilter),
        nameof(ItemFiltersEnum.BowsOfValueItemFilter),
        nameof(ItemFiltersEnum.DiggersOfValueItemFilter),
        nameof(ItemFiltersEnum.HaftedWeaponsOfValueItemFilter),
        nameof(ItemFiltersEnum.PolearmsOfValueItemFilter),
        nameof(ItemFiltersEnum.SwordsOfValueItemFilter)
    };

    public override string? AdvertisedStoreCommand4Name => nameof(EnchantWeaponStoreCommand);
}
