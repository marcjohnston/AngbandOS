namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class StaffsItemClass : ItemClass
{
    private StaffsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Staff";
    public override string Description => Pluralize(Name);
}