namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ScrollsItemClass : ItemClass
{
    private ScrollsItemClass(Game game) : base(game) { }
    public override string Name => "Scroll";
}