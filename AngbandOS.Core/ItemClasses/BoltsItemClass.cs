namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BoltsItemClass : ItemClass
{
    private BoltsItemClass(Game game) : base(game) { }
    public override string Name => "Bolt";
}