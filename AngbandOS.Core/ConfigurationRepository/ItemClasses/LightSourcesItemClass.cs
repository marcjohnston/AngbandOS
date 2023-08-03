namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class LightSourcesItemClass : ItemClass
{
    private LightSourcesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Light Sources";
}