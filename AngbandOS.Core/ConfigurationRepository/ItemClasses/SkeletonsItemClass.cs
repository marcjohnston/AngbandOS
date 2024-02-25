namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SkeletonsItemClass : ItemClass
{
    private SkeletonsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Skeleton";
    public override string Description => Pluralize(Name);
}