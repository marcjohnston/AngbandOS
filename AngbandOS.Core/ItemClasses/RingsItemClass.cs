namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class RingsItemClass : ItemClass
{
    private RingsItemClass(Game game) : base(game) { }
    public override string Name => "Ring";

    /// <summary>
    /// Returns the ring flavors repository because rings have flavors that need to be identified.
    /// </summary>
    protected override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(AdamantiteRingItemFlavor),
        nameof(AlexandriteRingItemFlavor),
        nameof(AmethystRingItemFlavor),
        nameof(AquamarineRingItemFlavor),
        nameof(AzuriteRingItemFlavor),
        nameof(BerylRingItemFlavor),
        nameof(BloodstoneRingItemFlavor),
        nameof(BoneRingItemFlavor),
        nameof(BrassRingItemFlavor),
        nameof(BronzeRingItemFlavor),
        nameof(CalciteRingItemFlavor),
        nameof(CarnelianRingItemFlavor),
        nameof(CorundumRingItemFlavor),
        nameof(DiamondRingItemFlavor),
        nameof(DilithiumRingItemFlavor),
        nameof(DoubleRingItemFlavor),
        nameof(EmeraldRingItemFlavor),
        nameof(EngagementRingItemFlavor),
        nameof(FlouriteRingItemFlavor),
        nameof(GarnetRingItemFlavor),
        nameof(GoldRingItemFlavor),
        nameof(GraniteRingItemFlavor),
        nameof(JadeRingItemFlavor),
        nameof(JasperRingItemFlavor),
        nameof(JetRingItemFlavor),
        nameof(LapisLazuliRingItemFlavor),
        nameof(MalachiteRingItemFlavor),
        nameof(MarbleRingItemFlavor),
        nameof(MithrilRingItemFlavor),
        nameof(MoonstoneRingItemFlavor),
        nameof(ObsidianRingItemFlavor),
        nameof(OnyxRingItemFlavor),
        nameof(OpalRingItemFlavor),
        nameof(PearlRingItemFlavor),
        nameof(PlainRingItemFlavor),
        nameof(PlatinumRingItemFlavor),
        nameof(QuartziteRingItemFlavor),
        nameof(QuartzRingItemFlavor),
        nameof(RhodoniteRingItemFlavor),
        nameof(RubyRingItemFlavor),
        nameof(RustyRingItemFlavor),
        nameof(SapphireRingItemFlavor),
        nameof(ScarabRingItemFlavor),
        nameof(SerpentRingItemFlavor),
        nameof(ShiningRingItemFlavor),
        nameof(SilverRingItemFlavor),
        nameof(SpikardRingItemFlavor),
        nameof(TigerEyeRingItemFlavor),
        nameof(TopazRingItemFlavor),
        nameof(TortoiseShellRingItemFlavor),
        nameof(TransparentRingItemFlavor),
        nameof(TurquiseRingItemFlavor),
        nameof(WeddingRingItemFlavor),
        nameof(WireRingItemFlavor),
        nameof(WoodenRingItemFlavor),
        nameof(ZirconRingItemFlavor),
    };
}