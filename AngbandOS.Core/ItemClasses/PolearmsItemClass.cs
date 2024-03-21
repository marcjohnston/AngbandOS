namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class PolearmsItemClass : ItemClass
{
    private PolearmsItemClass(Game game) : base(game) { }
    public override string Name => "Polearm";
}