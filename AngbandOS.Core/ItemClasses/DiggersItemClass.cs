namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class DiggersItemClass : ItemClass
{
    private DiggersItemClass(Game game) : base(game) { }
    public override string Name => "Digger";
}