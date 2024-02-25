namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ArrowsItemClass : ItemClass
{
    private ArrowsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Arrow";
    public override string Description => Pluralize(Name);
}