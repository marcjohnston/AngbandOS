namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class HaftedWeaponsItemClass : ItemClass
{
    private HaftedWeaponsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Hafted Weapons";
}