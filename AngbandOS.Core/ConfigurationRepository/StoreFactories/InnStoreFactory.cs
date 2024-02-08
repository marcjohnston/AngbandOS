// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class InnStoreFactory : StoreFactory
{
    private InnStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] ShopkeeperNames => new string[]
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

    protected override string TileName => "Inn";

    /// <summary>
    /// Returns an empty array of item criteria names because the inn doesn't buy items.
    /// </summary>
    protected override string[] ItemFilterNames => new string[] { };

    protected override StoreStockManifestDefinition[]? StoreStockManifestDefinitions => new[]
    {
        new StoreStockManifestDefinition(nameof(HardBiscuitFoodItemFactory), 2),
        new StoreStockManifestDefinition(nameof(PintOfFineAleFoodItemFactory), 10),
        new StoreStockManifestDefinition(nameof(PintOfFineWineFoodItemFactory), 10),
        new StoreStockManifestDefinition(nameof(RationFoodItemFactory), 18),
        new StoreStockManifestDefinition(nameof(StripOfVenisonFoodItemFactory), 4),
        new StoreStockManifestDefinition(nameof(SatisfyHungerScrollItemFactory), 4),
    };

    public override int MaxInventory => 4;

    /// <summary>
    /// Returns null, because the Inn doesn't buy items.
    /// </summary>
    protected override string? AdvertisedStoreCommand2Name => null;

    /// <summary>
    /// Returns the Hire A Room store command because the Inn allows the player to purchase a room for the night to rest.
    /// </summary>
    protected override string? AdvertisedStoreCommand4Name => nameof(HireRoomStoreCommand);

    public override bool PerformsMaintenanceWhenResting => false;
}
