namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class LightSourcesItemClass : ItemClass
{
    private LightSourcesItemClass(Game game) : base(game) { }
    public override string Name => "Light Source";
}