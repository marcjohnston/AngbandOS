namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SwordsItemClass : ItemClass
{
    private SwordsItemClass(Game game) : base(game) { }
    public override string Name => "Sword";
}