namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmuletsItemClass : ItemClassGameConfiguration
{
    public override string Name => "Amulet";

    /// <summary>
    /// Returns the amulet flavors repository because amulets have flavors that need to be identified.
    /// </summary>
    public override string[] ItemFlavorBindingKeys => new string[]
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