namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class PotionsItemClass : ItemClass
{
    private PotionsItemClass(Game game) : base(game) { }
    public override string Name => "Potion";

    /// <summary>
    /// Returns the potions flavors repository because potions have flavors that need to be identified.  The Apple Juice, Water and Slime-Mold
    /// potions override this
    /// </summary>
    protected override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(AzurePotionItemFlavor),
        nameof(BlackPotionItemFlavor),
        nameof(BluePotionItemFlavor),
        nameof(BlueSpeckledPotionItemFlavor),
        nameof(BrownPotionItemFlavor),
        nameof(BrownSpeckledPotionItemFlavor),
        nameof(BubblingPotionItemFlavor),
        nameof(ChartreusePotionItemFlavor),
        nameof(ClottedRedPotionItemFlavor),
        nameof(CloudyPotionItemFlavor),
        nameof(CoagulatedCrimsonPotionItemFlavor),
        nameof(CopperSpeckledPotionItemFlavor),
        nameof(CrimsonPotionItemFlavor),
        nameof(CyanPotionItemFlavor),
        nameof(DarkBluePotionItemFlavor),
        nameof(DarkGreenPotionItemFlavor),
        nameof(DarkRedPotionItemFlavor),
        nameof(EffervescentPotionItemFlavor),
        nameof(GloopyGreenPotionItemFlavor),
        nameof(GoldPotionItemFlavor),
        nameof(GoldSpeckledPotionItemFlavor),
        nameof(GreenPotionItemFlavor),
        nameof(GreenSpeckledPotionItemFlavor),
        nameof(GreyPotionItemFlavor),
        nameof(GreySpeckledPotionItemFlavor),
        nameof(HazyPotionItemFlavor),
        nameof(IchorPotionItemFlavor),
        nameof(IndigoPotionItemFlavor),
        nameof(IvoryWhitePotionItemFlavor),
        nameof(LightBluePotionItemFlavor),
        nameof(LightGreenPotionItemFlavor),
        nameof(MagentaPotionItemFlavor),
        nameof(MetallicBluePotionItemFlavor),
        nameof(MetallicGreenPotionItemFlavor),
        nameof(MetallicPurplePotionItemFlavor),
        nameof(MetallicRedPotionItemFlavor),
        nameof(MistyPotionItemFlavor),
        nameof(OilyBlackPotionItemFlavor),
        nameof(OilyYellowPotionItemFlavor),
        nameof(OrangePotionItemFlavor),
        nameof(OrangeSpeckledPotionItemFlavor),
        nameof(PinkPotionItemFlavor),
        nameof(PinkSpeckledPotionItemFlavor),
        nameof(PucePotionItemFlavor),
        nameof(PungentPotionItemFlavor),
        nameof(PurplePotionItemFlavor),
        nameof(PurpleSpeckledPotionItemFlavor),
        nameof(RedPotionItemFlavor),
        nameof(RedSpeckledPotionItemFlavor),
        nameof(ShimmeringPotionItemFlavor),
        nameof(SilverSpeckledPotionItemFlavor),
        nameof(SkyBluePotionItemFlavor),
        nameof(SmokyPotionItemFlavor),
        nameof(StinkingPotionItemFlavor),
        nameof(TangerinePotionItemFlavor),
        nameof(VermillionPotionItemFlavor),
        nameof(VioletPotionItemFlavor),
        nameof(VioletSpeckledPotionItemFlavor),
        nameof(ViscousPinkPotionItemFlavor),
        nameof(WhitePotionItemFlavor),
        nameof(YellowPotionItemFlavor),
        nameof(YellowSpeckledPotionItemFlavor),
    };
}