namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ShieldsItemClass : ItemClass
{
    private ShieldsItemClass(Game game) : base(game) { }
    public override string Name => "Shield";
}