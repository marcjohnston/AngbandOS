namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SoftArmorsItemClass : ItemClass
{
    private SoftArmorsItemClass(Game game) : base(game) { }
    public override string Name => "Soft Armor";
}