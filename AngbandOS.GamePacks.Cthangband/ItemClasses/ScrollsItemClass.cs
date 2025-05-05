namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScrollsItemClass : ItemClassGameConfiguration
{
    public override string Name => "Scroll";

    public override int NumberOfFlavorsToGenerate => 54;

    /// <summary>
    /// Returns the scroll flavors repository because scrolls have flavors that need to be identified.
    /// </summary>
    public override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(BeigeScrollItemFlavor),
        nameof(BrightBeigeScrollItemFlavor),
    };
}