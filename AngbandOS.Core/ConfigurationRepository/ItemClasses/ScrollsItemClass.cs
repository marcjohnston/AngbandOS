namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ScrollsItemClass : ItemClass
{
    private ScrollsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Scrolls";
}