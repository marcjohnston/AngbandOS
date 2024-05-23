namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ScrollsItemClass : ItemClass
{
    private ScrollsItemClass(Game game) : base(game) { }
    public override string Name => "Scroll";
    public override bool HasFlavor => true;

    /// <summary>
    /// Returns the scroll flavors repository because scrolls have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.UnreadableScrollFlavors;
}