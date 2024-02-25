namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class HelmsItemClass : ItemClass
{
    private HelmsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Helm";
    public override string Description => Pluralize(Name);
}