namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class StaffsItemClass : ItemClass
{
    private StaffsItemClass(Game game) : base(game) { }
    public override string Name => "Staff";


    /// <summary>
    /// Returns the staff flavors repository because staves have flavors that need to be identified.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository => Game.SingletonRepository.Get<StaffItemFlavor>();
}