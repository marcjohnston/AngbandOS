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

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(MagdTheRuthlessStoreOwner),
        nameof(DrakoFairdealStoreOwner),
        nameof(FeatherwingStoreOwner),
        nameof(XochinagguaStoreOwner),
        nameof(OdThePennilessStoreOwner),
        nameof(XaxStoreOwner),
        nameof(JakeSmallStoreOwner),
        nameof(HelgaTheLostStoreOwner),
        nameof(GloomThePhlegmaticStoreOwner),
        nameof(QuickArmVollaireStoreOwner),
        nameof(AsenathStoreOwner),
        nameof(LordFilbertStoreOwner),
        nameof(HerranythTheRuthlessStoreOwner),
        nameof(GagrinMoneylenderStoreOwner),
        nameof(ThramborTheGrubbyStoreOwner),
        nameof(DerigrinTheHonestStoreOwner),
        nameof(MunkTheBartererStoreOwner),
        nameof(GadrialdurTheFairStoreOwner),
        nameof(NinarTheStoopedStoreOwner),
        nameof(AdirathTheUnmagicalStoreOwner)
    };

    public override string FeatureType => "Pawnbrokers";
    public override ColorEnum Color => ColorEnum.Turquoise;
    protected override string SymbolName => nameof(NumberZeroSymbol);

    /// <summary>
    /// Returns the name of the item matching criteria for any items of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(AnythingOfValueItemFilter)
    };

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
    public override double MarkdownRate => 0.3;
    public override double MarkupRate => 0.3;

    protected override string? AdvertisedStoreCommand4Name => nameof(IdentifyAllStoreCommand);

    /// <summary>
    /// Returns false, because items in the pawn shop are not identified and render as they would appear in the dungeon.
    /// </summary>
    public override bool ItemsRenderFlavourAware => false;

    public override bool StoreIdentifiesItems => false;
    public override bool StoreAnalyzesPurchases => false;
    public override bool PerformsMaintenanceWhenResting => false;
    public override bool UseHomeCarry => true;
    public override bool BoughtMessageAsBoughtBack => true;
}
