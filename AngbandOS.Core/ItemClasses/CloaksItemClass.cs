namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class CloaksItemClass : ItemClass
{
    private CloaksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Cloak";
}