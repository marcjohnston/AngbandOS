namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class AmuletsItemClass : ItemClass
{
    private AmuletsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Amulet";
    public override string Description => Pluralize(Name);
}