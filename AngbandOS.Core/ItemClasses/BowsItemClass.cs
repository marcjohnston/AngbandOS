namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BowsItemClass : ItemClass
{
    private BowsItemClass(Game game) : base(game) { }
    public override string Name => "Bow";
}