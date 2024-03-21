namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class WandsItemClass : ItemClass
{
    private WandsItemClass(Game game) : base(game) { }
    public override string Name => "Wand";
}