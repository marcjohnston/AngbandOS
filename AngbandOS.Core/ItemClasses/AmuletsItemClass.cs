namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class AmuletsItemClass : ItemClass
{
    private AmuletsItemClass(Game game) : base(game) { }
    public override string Name => "Amulet";
}