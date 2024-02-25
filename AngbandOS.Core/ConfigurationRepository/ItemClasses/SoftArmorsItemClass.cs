namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SoftArmorsItemClass : ItemClass
{
    private SoftArmorsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Soft Armor";
    public override string Description => Pluralize(Name);
}