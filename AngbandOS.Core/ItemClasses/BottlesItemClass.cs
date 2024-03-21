namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BottlesItemClass : ItemClass
{
    private BottlesItemClass(Game game) : base(game) { }
    public override string Name => "Bottle";
}