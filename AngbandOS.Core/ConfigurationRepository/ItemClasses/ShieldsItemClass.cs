namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ShieldsItemClass : ItemClass
{
    private ShieldsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Shield";
    public override string Description => Pluralize(Name);
}