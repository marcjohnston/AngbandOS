// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class PawnStoreFactory : StoreFactory
{
    private PawnStoreFactory(SaveGame saveGame) : base(saveGame) { }

    public override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MagdTheRuthlessStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DrakoFairdealStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FeatherwingStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(XochinagguaStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(OdThePennilessStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(XaxStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(JakeSmallStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HelgaTheLostStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GloomThePhlegmaticStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(QuickArmVollaireStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AsenathStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(LordFilbertStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HerranythTheRuthlessStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GagrinMoneylenderStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ThramborTheGrubbyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(DerigrinTheHonestStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MunkTheBartererStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GadrialdurTheFairStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(NinarTheStoopedStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AdirathTheUnmagicalStoreOwner))
    };

    public override string FeatureType => "Pawnbrokers";
    public override ColourEnum Colour => ColourEnum.Turquoise;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(NumberZeroSymbol));

    public override bool ItemMatches(Item item)
    {
        return item.Value() > 0;
    }
    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return null;
    }

    public override bool MaintainsStockLevels => false;
    public override bool ShufflesOwnersAndPricing => false;
    public override string BoughtVerb => "pawn";

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
    public override int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
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
    public override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(IdentifyAllStoreCommand));
    public override string GetItemDescription(Item oPtr) => oPtr.Description(true, 3);

    public override bool StoreIdentifiesItems => false;
    public override bool StoreAnalyzesPurchases => false;
    public override bool PerformsMaintenanceWhenResting => false;
    public override bool UseHomeCarry => true;
    public override string BoughtMessage(string oName, int price) => $"You bought back {oName} for {price} gold.";

}
