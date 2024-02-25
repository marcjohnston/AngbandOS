namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ScrollsItemClass : ItemClass
{
    private ScrollsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Scroll";
    public override string Description => Pluralize(Name);
}