// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class InnStore : Store
{
    public InnStore(SaveGame saveGame) : base(saveGame) { }

    public override StoreType StoreType => StoreType.StoreInn;
    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<MordsanStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FurfootPobberStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<OddoYeeksonStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DryBonesStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<KleibonsStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<PrendegastStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<StraashaStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AlliaTheServileStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<LuminTheBlueStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ShortAlStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SilentFaldusStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<QuirmbyTheStrangeStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AldousTheSleepyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GrundyTheTallStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GobblegutsThunderbreathStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SilverscaleStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<EtheraaTheFuriousStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<PaetlanTheAlcoholicStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DrangStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BarbagTheSlyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<KirakakStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<NafurTheWoodenStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GrarakTheHospitableStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<LonaTheCharismaticStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<CrediricTheBrewerStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<NydudusTheSlowStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<BaurkTheBusyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SevirasTheMindcrafterStoreOwner>()
    };

    public override string FeatureType => "Inn";
    public override Colour Colour => Colour.Purple;
    public override char Character => '&';

    public override bool ItemMatches(Item item)
    {
        return false;
    }

    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(HardBiscuitFoodItemFactory), 2),
            new StockStoreInventoryItem(typeof(PintOfFineAleFoodItemFactory), 10),
            new StockStoreInventoryItem(typeof(PintOfFineWineFoodItemFactory), 10),
            new StockStoreInventoryItem(typeof(RationFoodItemFactory), 18),
            new StockStoreInventoryItem(typeof(StripOfVenisonFoodItemFactory), 4),
            new StockStoreInventoryItem(typeof(ScrollSatisfyHunger), 4),
        };
    }

    public override int StoreMaxKeep => 4;
    protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<HireRoomStoreCommand>();
    protected override bool PerformsMaintenanceWhenResting => false;
}
