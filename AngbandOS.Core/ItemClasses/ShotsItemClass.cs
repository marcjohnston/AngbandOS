namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ShotsItemClass : ItemClass
{
    private ShotsItemClass(Game game) : base(game) { }
    public override string Name => "Shot";
}