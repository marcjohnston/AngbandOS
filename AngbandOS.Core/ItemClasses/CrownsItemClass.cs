namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class CrownsItemClass : ItemClass
{
    private CrownsItemClass(Game game) : base(game) { }
    public override string Name => "Crown";
}