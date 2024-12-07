namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class AmuletsItemClass : ItemClass
{
    private AmuletsItemClass(Game game) : base(game) { }
    public override string Name => "Amulet";
    /// <summary>
    /// Returns the amulet flavors repository because amulets have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.SingletonRepository.Get<AmuletItemFlavor>();
}