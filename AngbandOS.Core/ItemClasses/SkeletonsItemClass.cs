namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SkeletonsItemClass : ItemClass
{
    private SkeletonsItemClass(Game game) : base(game) { }
    public override string Name => "Skeleton";
}