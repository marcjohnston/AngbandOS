namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class RodsItemClass : ItemClass
{
    private RodsItemClass(Game game) : base(game) { }
    public override string Name => "Rod";

    /// <summary>
    /// Returns the rod flavors repository because rods have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.SingletonRepository.Get<RodItemFlavor>();
}