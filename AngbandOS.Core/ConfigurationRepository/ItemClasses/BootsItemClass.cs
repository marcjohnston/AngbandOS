namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BootsItemClass : ItemClass
{
    private BootsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Boots";
    public override string Description => Name;
}