namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RodsItemClass : ItemClassGameConfiguration
{
    public override string Name => "Rod";

    /// <summary>
    /// Returns the rod flavors repository because rods have flavors that need to be identified.
    /// </summary>
    public override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(AdamantiteRodItemFlavor),
        nameof(AluminiumPlatedRodItemFlavor),
        nameof(AluminiumRodItemFlavor),
        nameof(BrassRodItemFlavor),
        nameof(BronzeRodItemFlavor),
        nameof(CastIronRodItemFlavor),
        nameof(ChromiumRodItemFlavor),
        nameof(CopperPlatedRodItemFlavor),
        nameof(CopperRodItemFlavor),
        nameof(GoldPlatedRodItemFlavor),
        nameof(GoldRodItemFlavor),
        nameof(HexagonalRodItemFlavor),
        nameof(IronRodItemFlavor),
        nameof(IvoryRodItemFlavor),
        nameof(LeadPlatedRodItemFlavor),
        nameof(LeadRodItemFlavor),
        nameof(LongRodItemFlavor),
        nameof(MagnesiumRodItemFlavor),
        nameof(MithrilPlatedRodItemFlavor),
        nameof(MithrilRodItemFlavor),
        nameof(MolybdenumRodItemFlavor),
        nameof(NickelPlatedRodItemFlavor),
        nameof(NickelRodItemFlavor),
        nameof(PlatinumRodItemFlavor),
        nameof(RunedRodItemFlavor),
        nameof(RustyRodItemFlavor),
        nameof(ShortRodItemFlavor),
        nameof(SilverPlatedRodItemFlavor),
        nameof(SilverRodItemFlavor),
        nameof(SteelPlatedRodItemFlavor),
        nameof(SteelRodItemFlavor),
        nameof(TinPlatedRodItemFlavor),
        nameof(TinRodItemFlavor),
        nameof(TitaniumRodItemFlavor),
        nameof(TungstenRodItemFlavor),
        nameof(UridiumRodItemFlavor),
        nameof(ZincRodItemFlavor),
        nameof(ZincPlatedRodItemFlavor),
        nameof(ZirconiumRodItemFlavor),
    };
}