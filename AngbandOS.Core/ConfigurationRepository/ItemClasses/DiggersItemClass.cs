namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class DiggersItemClass : ItemClass
{
    private DiggersItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Digger";
    public override string Description => Pluralize(Name);
}