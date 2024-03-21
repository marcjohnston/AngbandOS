namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class FlasksItemClass : ItemClass
{
    private FlasksItemClass(Game game) : base(game) { }
    public override string Name => "Flask";
}