namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class CrownsItemClass : ItemClass
{
    private CrownsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Crown";
}