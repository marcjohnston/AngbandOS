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

    public override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MordsanStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FurfootPobberStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(OddoYeeksonStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DryBonesStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(KleibonsStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(PrendegastStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(StraashaStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AlliaTheServileStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(LuminTheBlueStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ShortAlStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SilentFaldusStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(QuirmbyTheStrangeStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AldousTheSleepyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GrundyTheTallStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GobblegutsThunderbreathStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SilverscaleStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EtheraaTheFuriousStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(PaetlanTheAlcoholicStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DrangStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(BarbagTheSlyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(KirakakStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(NafurTheWoodenStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GrarakTheHospitableStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(LonaTheCharismaticStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(CrediricTheBrewerStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(NydudusTheSlowStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(BaurkTheBusyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SevirasTheMindcrafterStoreOwner))
    };

    public override string FeatureType => "Inn";
    public override ColourEnum Colour => ColourEnum.Purple;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(AmpersandSymbol));

    public override bool ItemMatches(Item item)
    {
        return false;
    }

    public override StockStoreInventoryItem[] GetStoreTable()
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
    public override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(HireRoomStoreCommand));
    public override bool PerformsMaintenanceWhenResting => false;
}
