namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class RingsItemClass : ItemClass
{
    private RingsItemClass(Game game) : base(game) { }
    public override string Name => "Ring";

    /// <summary>
    /// Returns the ring flavors repository because rings have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor> GetFlavorRepository => Game.SingletonRepository.Get<RingItemFlavor>();
}