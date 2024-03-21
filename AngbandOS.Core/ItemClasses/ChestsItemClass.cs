namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ChestsItemClass : ItemClass
{
    private ChestsItemClass(Game game) : base(game) { }
    public override string Name => "Chest";
}