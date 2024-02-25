namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BottlesItemClass : ItemClass
{
    private BottlesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Bottle";
    public override string Description => Pluralize(Name);
}