namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class HardArmorsItemClass : ItemClass
{
    private HardArmorsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Hard Armor";
    public override string Description => Pluralize(Name);
}