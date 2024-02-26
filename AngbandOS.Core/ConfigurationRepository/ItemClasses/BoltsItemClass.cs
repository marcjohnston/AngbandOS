namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BoltsItemClass : ItemClass
{
    private BoltsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Bolt";
}