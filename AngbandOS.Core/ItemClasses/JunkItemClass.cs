namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class JunkItemClass : ItemClass
{
    private JunkItemClass(Game game) : base(game) { }
    public override string Name => "Junk";
}