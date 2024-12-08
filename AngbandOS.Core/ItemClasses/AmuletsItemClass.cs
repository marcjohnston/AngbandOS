namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class AmuletsItemClass : ItemClass
{
    private AmuletsItemClass(Game game) : base(game) { }
    public override string Name => "Amulet";

    /// <summary>
    /// Returns the amulet flavors repository because amulets have flavors that need to be identified.
    /// </summary>
    protected override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(AgateAmuletItemFlavor),
        nameof(AmberAmuletItemFlavor),
        nameof(AzureAmuletItemFlavor),
        nameof(BoneAmuletItemFlavor),
        nameof(BrassAmuletItemFlavor),
        nameof(BronzeAmuletItemFlavor),
        nameof(CoralAmuletItemFlavor),
        nameof(CrystalAmuletItemFlavor),
        nameof(DriftwoodAmuletItemFlavor),
        nameof(EmeraldAmuletItemFlavor),
        nameof(GarnetAmuletItemFlavor),
        nameof(GoldenAmuletItemFlavor),
        nameof(IvoryAmuletItemFlavor),
        nameof(ObsidianAmuletItemFlavor),
        nameof(PewterAmuletItemFlavor),
        nameof(SapphireAmuletItemFlavor),
        nameof(SilverAmuletItemFlavor),
        nameof(TortoiseshellAmuletItemFlavor),
    };
}