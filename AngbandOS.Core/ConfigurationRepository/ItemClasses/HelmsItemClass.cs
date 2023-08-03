namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class HelmsItemClass : ItemClass
{
    private HelmsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Helms";
}