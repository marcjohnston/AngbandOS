namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class RodsItemClass : ItemClass
{
    private RodsItemClass(Game game) : base(game) { }
    public override string Name => "Rod";
}