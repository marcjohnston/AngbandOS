namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BootsItemClass : ItemClass
{
    private BootsItemClass(Game game) : base(game) { }
    public override string Name => "Boots";
}