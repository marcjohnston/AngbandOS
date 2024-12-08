namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ScrollsItemClass : ItemClass
{
    private ScrollsItemClass(Game game) : base(game) { }
    public override string Name => "Scroll";

    public override int NumberOfFlavorsToGenerate => 54;

    /// <summary>
    /// Returns the scroll flavors repository because scrolls have flavors that need to be identified.
    /// </summary>
    protected override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(BeigeScrollItemFlavor),
        nameof(BrightBeigeScrollItemFlavor),
    };
}