namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class MushroomItemClass : ItemClass
{
    private MushroomItemClass(Game game) : base(game) { }
    public override string Name => "Mushroom";
    /// <summary>
    /// Returns the mushroom flavors repository because mushrooms have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.SingletonRepository.Get<MushroomItemFlavor>();
}