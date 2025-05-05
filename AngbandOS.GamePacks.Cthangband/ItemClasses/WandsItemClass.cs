namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WandsItemClass : ItemClassGameConfiguration
{
    public override string Name => "Wand";

    /// <summary>
    /// Returns the want flavors repository because wands have flavors that need to be identified.
    /// </summary>
    public override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(AdamantiteWandItemFlavor),
        nameof(AluminiumPlatedWandItemFlavor),
        nameof(AluminiumWandItemFlavor),
        nameof(BrassWandItemFlavor),
        nameof(BronzeWandItemFlavor),
        nameof(CastIronWandItemFlavor),
        nameof(ChromiumWandItemFlavor),
        nameof(CopperPlatedWandItemFlavor),
        nameof(CopperWandItemFlavor),
        nameof(GoldPlatedWandItemFlavor),
        nameof(GoldWandItemFlavor),
        nameof(HexagonalWandItemFlavor),
        nameof(IronWandItemFlavor),
        nameof(IvoryWandItemFlavor),
        nameof(LeadPlatedWandItemFlavor),
        nameof(LeadWandItemFlavor),
        nameof(LongWandItemFlavor),
        nameof(MagnesiumWandItemFlavor),
        nameof(MithrilPlatedWandItemFlavor),
        nameof(MithrilWandItemFlavor),
        nameof(MolybdenumWandItemFlavor),
        nameof(NickelPlatedWandItemFlavor),
        nameof(NickelWandItemFlavor),
        nameof(PlatinumWandItemFlavor),
        nameof(RunedWandItemFlavor),
        nameof(RustyWandItemFlavor),
        nameof(ShortWandItemFlavor),
        nameof(SilverPlatedWandItemFlavor),
        nameof(SilverWandItemFlavor),
        nameof(SteelPlatedWandItemFlavor),
        nameof(SteelWandItemFlavor),
        nameof(TinPlatedWandItemFlavor),
        nameof(TinWandItemFlavor),
        nameof(TitaniumWandItemFlavor),
        nameof(TungstenWandItemFlavor),
        nameof(UridiumWandItemFlavor),
        nameof(ZincPlatedWandItemFlavor),
        nameof(ZincWandItemFlavor),
        nameof(ZirconiumWandItemFlavor),
    };
}