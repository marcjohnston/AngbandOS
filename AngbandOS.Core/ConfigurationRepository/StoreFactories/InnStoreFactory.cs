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

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(MordsanStoreOwner),
        nameof(FurfootPobberStoreOwner),
        nameof(OddoYeeksonStoreOwner),
        nameof(DryBonesStoreOwner),
        nameof(KleibonsStoreOwner),
        nameof(PrendegastStoreOwner),
        nameof(StraashaStoreOwner),
        nameof(AlliaTheServileStoreOwner),
        nameof(LuminTheBlueStoreOwner),
        nameof(ShortAlStoreOwner),
        nameof(SilentFaldusStoreOwner),
        nameof(QuirmbyTheStrangeStoreOwner),
        nameof(AldousTheSleepyStoreOwner),
        nameof(GrundyTheTallStoreOwner),
        nameof(GobblegutsThunderbreathStoreOwner),
        nameof(SilverscaleStoreOwner),
        nameof(EtheraaTheFuriousStoreOwner),
        nameof(PaetlanTheAlcoholicStoreOwner),
        nameof(DrangStoreOwner),
        nameof(BarbagTheSlyStoreOwner),
        nameof(KirakakStoreOwner),
        nameof(NafurTheWoodenStoreOwner),
        nameof(GrarakTheHospitableStoreOwner),
        nameof(LonaTheCharismaticStoreOwner),
        nameof(CrediricTheBrewerStoreOwner),
        nameof(NydudusTheSlowStoreOwner),
        nameof(BaurkTheBusyStoreOwner),
        nameof(SevirasTheMindcrafterStoreOwner)
    };

    public override string FeatureType => "Inn";
    public override ColorEnum Color => ColorEnum.Purple;
    protected override string SymbolName => nameof(AmpersandSymbol);

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
