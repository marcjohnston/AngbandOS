namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ArrowsItemClass : ItemClass
{
    private ArrowsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Arrows";
}