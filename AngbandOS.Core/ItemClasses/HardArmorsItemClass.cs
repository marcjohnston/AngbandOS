namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class HardArmorsItemClass : ItemClass
{
    private HardArmorsItemClass(Game game) : base(game) { }
    public override string Name => "Hard Armor";
}