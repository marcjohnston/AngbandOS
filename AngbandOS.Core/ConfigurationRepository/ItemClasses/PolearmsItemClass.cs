namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class PolearmsItemClass : ItemClass
{
    private PolearmsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Polearms";
}