namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class GlovesItemClass : ItemClass
{
    private GlovesItemClass(Game game) : base(game) { }
    public override string Name => "Gloves";
}