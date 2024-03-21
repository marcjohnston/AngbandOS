namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SpikesItemClass : ItemClass
{
    private SpikesItemClass(Game game) : base(game) { }
    public override string Name => "Spike";
}