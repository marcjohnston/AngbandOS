namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class LightSourcesItemClass : ItemClass
{
    private LightSourcesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Light Source";
}