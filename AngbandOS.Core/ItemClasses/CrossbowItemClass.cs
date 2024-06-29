namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class CrossbowItemClass : ItemClass
{
    private CrossbowItemClass(Game game) : base(game) { }
    public override string Name => "Crossbow";
}
