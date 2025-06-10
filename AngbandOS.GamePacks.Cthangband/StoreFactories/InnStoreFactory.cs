// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class InnStoreFactory : StoreFactoryGameConfiguration
{

    public override string[] ShopkeeperNames => new string[]
    {
        nameof(MordsanShopkeeper),
        nameof(FurfootPobberShopkeeper),
        nameof(OddoYeeksonShopkeeper),
        nameof(DryBonesShopkeeper),
        nameof(KleibonsShopkeeper),
        nameof(PrendegastShopkeeper),
        nameof(StraashaShopkeeper),
        nameof(AlliaTheServileShopkeeper),
        nameof(LuminTheBlueShopkeeper),
        nameof(ShortAlShopkeeper),
        nameof(SilentFaldusShopkeeper),
        nameof(QuirmbyTheStrangeShopkeeper),
        nameof(AldousTheSleepyShopkeeper),
        nameof(GrundyTheTallShopkeeper),
        nameof(GobblegutsThunderbreathShopkeeper),
        nameof(SilverscaleShopkeeper),
        nameof(EtheraaTheFuriousShopkeeper),
        nameof(PaetlanTheAlcoholicShopkeeper),
        nameof(DrangShopkeeper),
        nameof(BarbagTheSlyShopkeeper),
        nameof(KirakakShopkeeper),
        nameof(NafurTheWoodenShopkeeper),
        nameof(GrarakTheHospitableShopkeeper),
        nameof(LonaTheCharismaticShopkeeper),
        nameof(CrediricTheBrewerShopkeeper),
        nameof(NydudusTheSlowShopkeeper),
        nameof(BaurkTheBusyShopkeeper),
        nameof(SevirasTheMindcrafterShopkeeper)
    };

    public override string TileName => nameof(InnStoreTile);

    /// <summary>
    /// Returns an empty array of item criteria names because the inn doesn't buy items.
    /// </summary>
    public override string[] ItemFilterNames => new string[] { };

    public override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(HardBiscuitFoodItemFactory), 2),
        (nameof(PintOfFineAleFoodItemFactory), 10),
        (nameof(PintOfFineWineFoodItemFactory), 10),
        (nameof(RationFoodItemFactory), 18),
        (nameof(StripOfVenisonFoodItemFactory), 4),
        (nameof(SatisfyHungerScrollItemFactory), 4),
    };

    public override int MaxInventory => 4;

    /// <summary>
    /// Returns null, because the Inn doesn't buy items.
    /// </summary>
    public override string? AdvertisedStoreCommand2Name => null;

    /// <summary>
    /// Returns the Hire A Room store command because the Inn allows the player to purchase a room for the night to rest.
    /// </summary>
    public override string? AdvertisedStoreCommand4Name => nameof(HireRoomStoreCommand);

    public override bool PerformsMaintenanceWhenResting => false;
}
