namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class WandsItemClass : ItemClass
{
    private WandsItemClass(Game game) : base(game) { }
    public override string Name => "Wand";

    /// <summary>
    /// Returns the want flavors repository because wands have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.SingletonRepository.Get<WandReadableFlavor>();

}