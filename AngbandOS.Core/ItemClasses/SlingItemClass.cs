namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SlingItemClass : ItemClass
{
    private SlingItemClass(Game game) : base(game) { }
    public override string Name => "Sling";
}