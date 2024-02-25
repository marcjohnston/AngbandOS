namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ShotsItemClass : ItemClass
{
    private ShotsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Shot";
    public override string Description => Pluralize(Name);
}