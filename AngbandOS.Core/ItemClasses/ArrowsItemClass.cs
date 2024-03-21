namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ArrowsItemClass : ItemClass
{
    private ArrowsItemClass(Game game) : base(game) { }
    public override string Name => "Arrow";
}