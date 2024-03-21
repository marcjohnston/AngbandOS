namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class CloaksItemClass : ItemClass
{
    private CloaksItemClass(Game game) : base(game) { }
    public override string Name => "Cloak";
}