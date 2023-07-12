// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class PawnStore : Store
{
    public PawnStore(SaveGame saveGame) : base(saveGame) { }

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<MagdTheRuthlessStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DrakoFairdealStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FeatherwingStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<XochinagguaStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<OdThePennilessStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<XaxStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<JakeSmallStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HelgaTheLostStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GloomThePhlegmaticStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<QuickArmVollaireStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AsenathStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<LordFilbertStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HerranythTheRuthlessStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GagrinMoneylenderStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ThramborTheGrubbyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<DerigrinTheHonestStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<MunkTheBartererStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GadrialdurTheFairStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<NinarTheStoopedStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AdirathTheUnmagicalStoreOwner>()
    };

    public override string FeatureType => "Pawnbrokers";
    public override ColourEnum Colour => ColourEnum.Turquoise;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<NumberZeroSymbol>();

    public override bool ItemMatches(Item item)
    {
        return item.Value() > 0;
    }
    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return null;
    }

    protected override bool MaintainsStockLevels => false;
    public override bool ShufflesOwnersAndPricing => false;
    protected override string BoughtVerb => "pawn";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="price"></param>
    /// <param name="trueToMarkDownFalseToMarkUp"></param>
    /// <returns></returns>
    /// <remarks>
    /// Per Dean Anderson, 7/22/2022
    ///Thepawn shop both buys and sells cheaply.Thewhole idea is that if you need cash you can pawn items
    /// (for less money than you could sell them for), inTheknowledge thatTheshop will hold onto them and then buy
    /// them back later forTheamount you pawned them for. If retrieving your items fromThepawn shop had a
    /// markup then you'd be better off just selling them  normally and buying new ones to replace them.
    /// </remarks>
    protected override int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
    {
        if (trueToMarkDownFalseToMarkUp == true)
        {
            return price / 3;
        }
        else
        {
            return price / 3;
        }
    }
    protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<IdentifyAllStoreCommand>();
    protected override string GetItemDescription(Item oPtr) => oPtr.Description(true, 3);

    protected override bool StoreIdentifiesItems => false;
    protected override bool StoreAnalyzesPurchases => false;
    protected override bool PerformsMaintenanceWhenResting => false;
    protected override int CarryItem(Item qPtr) => HomeCarry(qPtr);
    protected override string BoughtMessage(string oName, int price) => $"You bought back {oName} for {price} gold.";

}
