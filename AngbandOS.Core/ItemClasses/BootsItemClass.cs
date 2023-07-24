[Serializable]
internal class BootsItemClass : ItemClass
{
    private BootsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Boots";
}