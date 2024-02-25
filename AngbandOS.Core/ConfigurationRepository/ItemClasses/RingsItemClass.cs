namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class RingsItemClass : ItemClass
{
    private RingsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Ring";
    public override string Description => Pluralize(Name);
}