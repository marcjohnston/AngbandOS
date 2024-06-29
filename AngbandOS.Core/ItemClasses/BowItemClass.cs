namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BowItemClass : ItemClass
{
    private BowItemClass(Game game) : base(game) { }
    public override string Name => "Bow";
}
