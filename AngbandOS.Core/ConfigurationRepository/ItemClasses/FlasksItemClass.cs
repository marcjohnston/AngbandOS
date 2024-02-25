namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class FlasksItemClass : ItemClass
{
    private FlasksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Flask";
    public override string Description => Pluralize(Name);
}