namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class WandsItemClass : ItemClass
{
    private WandsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Wand";
    public override string Description => Pluralize(Name);
}