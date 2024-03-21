namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class HaftedWeaponsItemClass : ItemClass
{
    private HaftedWeaponsItemClass(Game game) : base(game) { }
    public override string Name => "Hafted Weapon";
}