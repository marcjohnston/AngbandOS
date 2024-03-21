namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class HelmsItemClass : ItemClass
{
    private HelmsItemClass(Game game) : base(game) { }
    public override string Name => "Helm";
}