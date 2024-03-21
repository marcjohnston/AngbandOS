namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class RingsItemClass : ItemClass
{
    private RingsItemClass(Game game) : base(game) { }
    public override string Name => "Ring";
}